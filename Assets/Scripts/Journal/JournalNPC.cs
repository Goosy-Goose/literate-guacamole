using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalNPC : MonoBehaviour
{

    public Text LeftText, RightText, NameText;

    public void SetNPCJournal(Page NPCPage)
    {
        NameText.text = NPCPage.GetName();
        LeftText.text = NPCPage.GetLeftPage();
        RightText.text = NPCPage.GetRightPage();
    }
}
