using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObjectManager : MonoBehaviour
{
    public SmartObject[] smartObjects;
    // Start is called before the first frame update
    void Start()
    {
        smartObjects = GetComponentsInChildren<SmartObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SmartObject[] getSmartObjects(BasicHero a){
        return smartObjects;
    }
}
