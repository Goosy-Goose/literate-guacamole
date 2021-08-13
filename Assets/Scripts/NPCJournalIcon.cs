using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCJournalIcon : SpriteTouch
{

    public NPCJournal NPCPage;
    protected override void MouseUP()
    {
        FindObjectOfType<MatchingGame>().LoadNPCJournalButton(NPCPage);
    }

    public void SetNPCJournal(NPCJournal journal)
    {
        NPCPage = journal;
    }

    
}
