using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Page", menuName = "Journal/Page")]
public class NPCJournal : ScriptableObject
{

    public string Name;
    [TextArea] public string[] LeftPage;
    [TextArea] public string[] RightPage;
    public bool[] LeftUnlocked;
    public bool[] RightUnlocked;

    public MatchingItem[] MatchingItems;

    public string GetLeftPage()
    {
        return GetPage(LeftPage, LeftUnlocked);
    }
    public string GetRightPage()
    {
        return GetPage(RightPage, RightUnlocked);
    }

    public string GetName()
    {
        return Name;
    }


    private string GetPage(string[] side, bool[] unlocked)
    {
        string page = "";
        for(int i = 0; i < side.Length; i += 1)
        {
            page += GetText(side[i], unlocked[i]);
            page += "\n\n";
        }
        return page;
    }


    private string GetText(string text, bool isUnlocked)
    {
        if (isUnlocked)
            return text;
        else
        {
            string display = "";
            for(int i=0; i<text.Length; i += 1)
            {
                display += "-";
            }
            return display;
        }
    }

    
}

[System.Serializable]
public class MatchingItem
{
    public string Name;
    public GameObject Icon;
    public GameObject Item;
    public bool matched;
    public int RightPageIndex = -1;
}
