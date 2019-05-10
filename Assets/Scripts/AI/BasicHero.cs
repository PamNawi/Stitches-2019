using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BasicNeeds))]
[RequireComponent (typeof(UnityEngine.AI.NavMeshAgent))]
public class BasicHero : MonoBehaviour
{
    BasicNeeds personalNeeds;

    SmartObjectManager soM;
    public SmartObject interacting = null;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        personalNeeds = GetComponent<BasicNeeds>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
            if((originalHappiness + impact > majorHappiness) ||
            (originalHappiness + impact == majorHappiness && Vector3.Distance(s.transform.position, transform.position) < Vector3.Distance(so.transform.position, transform.position)))
            {
                majorHappiness = originalHappiness + impact;
                so = s;
            }
        }
        return so;
    }
}
