using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Need {
    public float total;
    public float baseStats;
    public NeedInfo needInfo;

    public float Update(){
        total = needInfo.decay.Evaluate(baseStats) * 100f;
        return total;
    }

    public float Decay(){
        baseStats =  Mathf.Clamp(baseStats - 0.1f, 0f, 1f);
        return baseStats;
    }

    public float calculateImpact(float baseChange){
        return needInfo.decay.Evaluate(baseStats + baseChange) * 100f;
    }
}

