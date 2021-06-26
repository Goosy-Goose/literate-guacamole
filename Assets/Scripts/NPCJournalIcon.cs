using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJournalIcon : SpriteTouch
{
    public NPCJournal NPCPage;

    protected override void MouseUp()
    {
        Loading loading = FindObjectOfType<Loading>();
        loading.NPCPage = NPCPage;
        loading.PlayerJournal = false;
        loading.LoadingButton("JournalTesting");
    }
}
