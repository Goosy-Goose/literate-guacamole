using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Journal", menuName = "Journal/Journal")]
public class Journal : ScriptableObject
{
   
    public List<PageEntry> pages = new List<PageEntry>();


}
