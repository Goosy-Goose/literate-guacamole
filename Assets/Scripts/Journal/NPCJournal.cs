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

    public MatchPair[] MatchingPair;

    public GameObject NPCBody;

    public Vector2 LastStandingPos;


    private string GetText(string text, bool isUnlocked)
    {
        if (isUnlocked)
            return text;
        else
        {
            string display = "";
            for (int i = 0; i < text.Length; i += 1)
            {
                display += "-";
            }
            return display;
        }
    }//end method
    private string GetPage(string[] side, bool[] unlocked)
    {
        string page = "";
        for (int i = 0; i < side.Length; i += 1)
        {
            page += GetText(side[i], unlocked[i]);
            page += "\n\n";
        }
        return page;
    }//end method



//GET METHODS THAT CALL OTHER METHODS
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


    public GameObject[] GetMatchingIcons()
    {
        GameObject[] matchingIcons = new GameObject[2];
        if (MatchingPair.Length == 2)
        {
            if (!MatchingPair[0].Matched)
            {
                matchingIcons[0] = MatchingPair[0].Icon;
                Debug.Log(Name + " Matching Icon 1");
            }
            if (!MatchingPair[1].Matched)
            {
                matchingIcons[1] = MatchingPair[1].Icon;
                Debug.Log(Name + " Matching Icon 2");
            }
        }
        else if (MatchingPair.Length == 1)
        {
            //return one;
        }
        else
        {
            //pick two randomly to return;
        }

        return matchingIcons;
    }



    

    
}//END OF CLASS


