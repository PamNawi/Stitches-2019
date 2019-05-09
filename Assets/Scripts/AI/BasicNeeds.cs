using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNeeds : MonoBehaviour
{
    public List<NeedInfo> needs;
    public StringNeedDictionary personalNeeds = new StringNeedDictionary();
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (NeedInfo n in needs){
            Need clone = new Need();
            clone.needInfo = n;
            clone.baseStats = 1f;
            clone.Update();
            personalNeeds.Add(clone.needInfo.name,clone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DecayStatus();
        UpdateStatus();
    }

    void UpdateStatus(){
        foreach(Need pn in personalNeeds.Values){
            pn.Update();
        }
    }

    void DecayStatus(){
        foreach(Need pn in personalNeeds.Values){
            pn.Decay();
        }
    }

    public float calculateHappiness(){
        float happiness = 0;
        foreach(Need pn in personalNeeds.Values){
            happiness += pn.total;
        }
        return happiness;
    }

    public float calculateImpactOnHappiness(List<NeedUpdate> needUpdate){
        float impact = 0;
        foreach(NeedUpdate nu in needUpdate){
            impact += personalNeeds[nu.needInfo.name].calculateImpact(nu.baseStats);
        }
        return impact;
    }
}
