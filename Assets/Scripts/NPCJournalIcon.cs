using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJournalIcon : SpriteTouch
{

    public NPCJournal NPCPage;
    protected override void MouseUP()
    {
        Loading loading = FindObjectOfType<Loading>();
        loading.NPCPage = NPCPage;
        loading.PlayerJournal = false;
        loading.LoadingButton("JournalTesting");
    }


}
