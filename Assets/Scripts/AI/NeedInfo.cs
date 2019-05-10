using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Need Information", menuName = "Stitches/Need", order = 0)]
public class NeedInfo : ScriptableObject
{
    public string needName;
    public AnimationCurve decay;
}