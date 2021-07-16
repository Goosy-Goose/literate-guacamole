using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJournalIcon : SpriteTouch
{

    private NPCJournal NPCPage;
    protected override void MouseUP()
    {
        Loading loading = FindObjectOfType<Loading>();
        loading.NPCPage = NPCPage;
        loading.PlayerJournal = false;
        loading.LoadingButton("JournalTesting");
    }

    public void SetNPCJournal(NPCJournal journal)
    {
        NPCPage = journal;
    }

}
