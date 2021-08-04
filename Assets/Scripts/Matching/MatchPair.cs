using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MatchPair 
{
    public string Name;
    public GameObject Icon; //icon in the thought bubble
    public GameObject Item; //item being bought
    public bool Matched;
    public int RightPageIndex = -1;
}
