using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    
    public Journal journal;
    public Warning warningPanel;
    public PageUI PageEntryPanel;
    public PageHistoryUI PageHistoryPanel;
    public JournalNPC PageNPCPanel;

    public GameObject ForwardButton, BackwardButton;

    private void Start()
    {
        OpenJournal();
    }

//OPEN DIFFERENT JOURNAL METHODS
    public void OpenJournal()
    {
        if (journal.PlayerJournal)
        {
            OpenPlayerJournal();
        }
        else
        {
            OpenNPCJournal();
        }
    }

    public void OpenPlayerJournal()
    {
        PageNPCPanel.gameObject.SetActive(false);
        ForwardButton.SetActive(true);
        BackwardButton.SetActive(true);
        int pageCount = journal.pages.Count;
        if (pageCount > 0 && !ValidNewEntry())
        {
            pageIndex = pageCount - 1;
            PageEntry lastEntry = journal.pages[pageCount - 1];
            DisplayPageEntry(false);
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

    public void OpenNPCJournal()
    {
        PageEntryPanel.gameObject.SetActive(false);
        PageHistoryPanel.gameObject.SetActive(false);
        PageNPCPanel.gameObject.SetActive(true);
        ForwardButton.SetActive(false);
        BackwardButton.SetActive(false);
        PageNPCPanel.SetNPCJournal(journal.NPCPage);
        
    }


    public void SubmitPage(PageEntry page)
    {
        if (warningPanel.SetWarning(page)) {
            journal.AddPageEntry(page);
            DisplayPageEntry(false);
            pageIndex = journal.pages.Count - 1;
            DisplayPageHistory(page);
        }
        
    }

    

    

    

    
//DISPLAY METHODS
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





//SIDE BUTTON METHODS < > x
    int pageIndex;
    public void TurnPageForward()
    {
        if(pageIndex < journal.pages.Count-1)
        {
            pageIndex += 1;
            DisplayPageHistory(journal.pages[pageIndex]);
        } else if( pageIndex == journal.pages.Count-1 && ValidNewEntry()) {
            pageIndex += 1;
            DisplayPageEntry(true);
        }
    }
    public void TurnPageBackward()
    {
        if(pageIndex > 0 && pageIndex < journal.pages.Count)
        {
            pageIndex -= 1;
            DisplayPageHistory(journal.pages[pageIndex]);
        } else if(pageIndex == journal.pages.Count)
        {
            pageIndex -= 1;
            DisplayPageHistory(journal.pages[pageIndex]);
            DisplayPageEntry(false);
        }
    }

    public void CloseJournal()
    {
        if (journal.ReturnScene.Equals("Matching")) 
        {
            journal.MatchGameReturn = true;
        }
        else
        {
            journal.MatchGameReturn = false;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(journal.ReturnScene);
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
