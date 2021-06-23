using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalNPC : MonoBehaviour
{

    public Page NPCPage;
    public Text LeftText, RightText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNPCJournal()
    {
        LeftText.text = NPCPage.GetLeftPage();
        RightText.text = NPCPage.GetRightPage();
    }
}
