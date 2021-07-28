using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    public GameObject NPCPrefab;
    public NPCJournal[] NPCJournals;
    List<NPCJournal> ActiveJournals = new List<NPCJournal>();
    public Journal journal;

    // Start is called before the first frame update
    void Start()
    {
        LoadNPC();
        journal.MatchGameReturn = false;
    }

    

        
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadMatchItems()
    {

    }

    private void LoadNPC()
    {
        List<NPCJournal> available = Utility.GetList<NPCJournal>(NPCJournals);
        if(journal.MatchGameReturn){
            for(int i=0; i<journal.MatchGameNPCs.Count; i++)
            {
                GameObject newNPC = Instantiate(NPCPrefab, journal.MatchGameNPCs[i].LastStandingPos, Quaternion.identity);
                newNPC.GetComponent<NPC>().SetupNPC(journal.MatchGameNPCs[i]);
            }
        }
        else
        {
            for (int i = 0; i < 3; i += 1)
            {
                Vector2 pos = new Vector2(-10, 3);
                GameObject newNPC = Instantiate(NPCPrefab, pos, Quaternion.identity);
                int index = Random.Range(0, available.Count);
                newNPC.GetComponent<NPC>().SetupNPC(available[index]);
                ActiveJournals.Add(available[index]);
                available.RemoveAt(index);
            }
            journal.MatchGameNPCs = ActiveJournals;
        }
    }


    public void LoadNPCJournalButton(NPCJournal NPCPage)
    {
        journal.PlayerJournal = false;
        journal.MatchGameReturn = true;
        Loading loading = FindObjectOfType<Loading>();
        loading.NPCPage = NPCPage;
        loading.PlayerJournal = false;

        NPC[] npcs = FindObjectsOfType<NPC>();
        foreach(NPC npc in npcs)
        {
            GameObject gameObject = npc.gameObject;
            Vector2 pos = gameObject.transform.position;
            npc.journalIcon.NPCPage.LastStandingPos = pos;
        }

        loading.LoadingButton("JournalTesting");
    }

}
