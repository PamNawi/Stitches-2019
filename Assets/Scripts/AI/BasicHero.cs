using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BasicNeeds))]
public class BasicHero : MonoBehaviour
{
    public BasicNeeds personalNeeds;

    SmartObjectManager soM;
    public SmartObject interacting = null;
    // Start is called before the first frame update
    void Start()
    {
        personalNeeds = GetComponent<BasicNeeds>();
        soM = GameObject.FindGameObjectWithTag("SmartObjectsManager").GetComponent<SmartObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!interacting)
        {
            interacting = searchSmartObject();
        }
    }

    SmartObject searchSmartObject(){
        SmartObject so = new SmartObject();
        float originalHappiness = personalNeeds.calculateHappiness();
        float majorHappiness = originalHappiness;
        SmartObject[] vSmartObjects = soM.getSmartObjects(this);
        foreach(SmartObject s in vSmartObjects){
            float impact = personalNeeds.calculateImpactOnHappiness(s.changedNeed);
            Debug.Log(originalHappiness + impact);
            if(originalHappiness + impact > majorHappiness){
                majorHappiness = originalHappiness + impact;
                so = s;
            }
        }
        Debug.Log(so);
        return so;
    }
}
