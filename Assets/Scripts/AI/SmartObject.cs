using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObject : BehaviorExecutor
{
    //Behavior Component
    public List<NeedUpdate> changedNeed = new List<NeedUpdate>();

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        this.enabled = false;
    }
}
