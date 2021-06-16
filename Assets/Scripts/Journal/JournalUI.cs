using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    public Journal journal;

    public void SubmitPage(PageEntry page)
    {
        journal.pages.Add(page);
    }



    public void TurnPageForward()
    {

    }
    public void TurnPageBackward()
    {

    }

    public void CloseJournal()
    {

    }

//Button methods
    public void TurnPageForwardButton()
    {
        TurnPageForward();
    }
    public void TurnPageBackwardButton()
    {
        TurnPageBackward();
    }

    public void CloseJournalButton()
    {
        CloseJournal();
    }
}
