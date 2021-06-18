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
        PageEntryPanel.gameObject.SetActive(false);
        PageHistoryPanel.gameObject.SetActive(true);
        PageHistoryPanel.LoadPage(journal.pages[journal.pages.Count - 1]);
    }

    public void SubmitPage(PageEntry page)
    {
        if (warningPanel.setWarning(page))
        {
            journal.pages.Add(page);
        }
            
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
