using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JournalUI : MonoBehaviour
{
    public Journal journal;
    //public void TestButton()
    //{
    //    PageEntry page = new PageEntry();
    //    page.Answer1 = 5;
    //    page.Answer2 = "hljlje";
    //    page.Answer3 = "sfsare";
    //    DateTime dateTime = new DateTime();
    //    page.Date = dateTime.Date.ToLongDateString();
    //    journal.pages.Add(page);
    //}

    public void SubmitPage(PageEntry page)
    {
        journal.pages.Add(page);
    }

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

    public void TurnPageForward()
    {

    }

    public void TurnPageBackward()
    {

    }

    public void CloseJournal()
    {

    }
}
