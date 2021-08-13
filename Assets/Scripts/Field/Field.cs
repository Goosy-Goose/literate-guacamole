using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    public GameObject NPCPrefab;
    public BoxCollider2D[] Bounds;
    public Journal journal;
    public NPCJournal[] NPCJournals;




    // Start is called before the first frame update
    void Start()
    {
        LoadNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LoadNPC()
    {
        for(int i=0; i<NPCJournals.Length; i += 1)
        {
            Vector2 pos = GetNewNPCPos();
            GameObject newNPC = Instantiate(NPCPrefab, pos, Quaternion.identity);
            newNPC.GetComponent<NPC>().SetupNPC(NPCJournals[i]);
        }
    }

    public void LoadNPCJournalButton(NPCJournal NPCPage)
    {
        journal.PlayerJournal = false;
        Loading loading = FindObjectOfType<Loading>();
        loading.NPCPage = NPCPage;
        loading.PlayerJournal = false;

        NPC[] npcs = FindObjectsOfType<NPC>();
        foreach (NPC npc in npcs)
        {
            GameObject gameObject = npc.gameObject;
            Vector2 pos = gameObject.transform.position;
            npc.journalIcon.NPCPage.LastStandingPos = pos;
        }
        
        loading.LoadingButton("JournalTesting");
    }


    public Vector2 GetNewNPCPos()
    {
        Vector2 point = Vector2.zero;
        bool done = false;
        while (!done)
        {
            point = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            done = true;
            foreach (BoxCollider2D bound in Bounds)
            {
                if (bound.OverlapPoint(point)) done = false;
            }
        }
        return point; 
    }

}
