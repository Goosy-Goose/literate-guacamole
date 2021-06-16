using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PageEntry 
{
    public string Date;
    public PageUI.Q1Feelings Answer1;
    [TextArea] public string Answer2;
    [TextArea] public string Answer3;

}
