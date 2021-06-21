using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    public Journal journal;
    public Warning warningPanel;
    public PageUI PageEntryPanel;
    public PageHistoryUI PageHistoryPanel;

    private void Start()
    {
        OpenJournal();
        //PageHistoryPanel.LoadPage(journal.pages[journal.pages.Count - 1]);
    }

    public void SubmitPage(PageEntry page)
    {
        if (warningPanel.setWarning(page))
        {
            journal.pages.Add(page);
            DisplayPageEntry(false);
            DisplayPageHistory(page);
        }
        

    }


    public void OpenJournal()
    {
        int pageCount = journal.pages.Count;
        if(pageCount > 0 && !ValidNewEntry())
        {
            pageIndex = pageCount - 1;
            PageEntry lastEntry = journal.pages[pageCount - 1];
            DisplayPageHistory(lastEntry);
        }
        else
        {
            pageIndex = pageCount;
            DisplayPageEntry(true);
        }
    }
    private bool ValidNewEntry()
    {
        return journal.pages[journal.pages.Count - 1].Date != Utility.GetDate();
    }

    private void DisplayPageHistory(PageEntry page)
    {
        PageHistoryPanel.LoadPage(page);
    }

    private void DisplayPageEntry(bool displayEntry)
    {
        if (displayEntry)
        {
            PageEntryPanel.gameObject.SetActive(true);
            PageHistoryPanel.gameObject.SetActive(false);
        }
        else
        {
            PageEntryPanel.gameObject.SetActive(false);
            PageHistoryPanel.gameObject.SetActive(true);
        }
    }

    int pageIndex;
    
    public void TurnPageForward()
    {
        if(pageIndex < journal.pages.Count - 1)
        {
            pageIndex += 1;
            DisplayPageHistory(journal.pages[pageIndex]);
        }else if (pageIndex < journal.pages.Count && ValidNewEntry())
        {
            DisplayPageEntry(true);
        }
    }
    public void TurnPageBackward()
    {
        if(pageIndex > 0 && pageIndex < journal.pages.Count)
        {
            pageIndex -= 1;
            DisplayPageHistory(journal.pages[pageIndex]);
        }else if(pageIndex == journal.pages.Count)
        {
            pageIndex -= 1;
            DisplayPageHistory(journal.pages[pageIndex]);
            DisplayPageEntry(false);
        }
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
