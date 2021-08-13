using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    public GameObject NPCPrefab;
    public NPCJournal[] NPCJournals;
    List<NPCJournal> ActiveJournals = new List<NPCJournal>();
    public Journal journal;

    public BoxCollider2D[] Bounds;

    public Transform[] shelfItem;

    public int numMatched;

    // Start is called before the first frame update
    void Start()
    {
        ResetMatches();
        LoadNPC();
        LoadMatchItems();
        journal.MatchGameReturn = false;
    }

    

        
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadMatchItems()
    {
        

        List<MatchPair> listOfShelfPlaces = new List<MatchPair>(); //index Transform[] shelfItem; (same size, use this list to instantiate items) size 5 [0,1,2, -3, -6]

        if (!journal.MatchGameReturn)
        {
            //List<int> listOfNPCItemsIndex = new List<int>(); //index MatchingItems[] ActiveJournals.MatchingItems [0,1,2]
            List<MatchPair> listOfNPCItems = new List<MatchPair>();
            //List<int> ListOfExtraNPCItemsIndex = new List<int>(); // index MatchingItems[] NPCJournals.MatchingItems - listOfNPCItems [-1, -2, -3, -4, -5, -6]
            List<MatchPair> ListOfExtraNPCItems = new List<MatchPair>();

            foreach (NPCJournal npc in ActiveJournals)
            {
                foreach (MatchPair matchPair in npc.MatchingPair)
                {
                    listOfNPCItems.Add(matchPair);
                }
            }

            //populate the listOfExtraNPCItmes
            foreach (NPCJournal NPCJournal in NPCJournals)
            {
                foreach (MatchPair matchPair in NPCJournal.MatchingPair)
                {
                    if (!listOfNPCItems.Contains(matchPair))
                    {
                        ListOfExtraNPCItems.Add(matchPair);
                    }

                }
            }

            while (listOfShelfPlaces.Count < shelfItem.Length && listOfNPCItems.Count > 0)
            {
                listOfShelfPlaces.Add(listOfNPCItems[0]);
                listOfNPCItems.RemoveAt(0);
            }
            while (listOfShelfPlaces.Count < shelfItem.Length && ListOfExtraNPCItems.Count > 0)
            {
                listOfShelfPlaces.Add(ListOfExtraNPCItems[0]);
                ListOfExtraNPCItems.RemoveAt(0);
            }

            for (int i = 0; i < listOfShelfPlaces.Count; i += 1)
            {
                int j = Random.Range(0, listOfShelfPlaces.Count);
                MatchPair temp = listOfShelfPlaces[i];
                listOfShelfPlaces[i] = listOfShelfPlaces[j];
                listOfShelfPlaces[j] = temp;
            }

            journal.ListOfShelfPlaces = listOfShelfPlaces;
        }
        else
        {
            listOfShelfPlaces = journal.ListOfShelfPlaces;
        }
        
        for(int i=0; i<listOfShelfPlaces.Count; i += 1)
        {
            if (!listOfShelfPlaces[i].Matched)
            {
                GameObject item = Instantiate(listOfShelfPlaces[i].Item, shelfItem[i]);
            }
        }
    }


    private List<GameObject> GetItemsToMatch()
    {
        List<GameObject> items = new List<GameObject>();
        foreach(NPCJournal journal in NPCJournals)
        {
            foreach(MatchPair pair in journal.MatchingPair)
            {
                items.Add(pair.Item);
            }
        }
        return items;
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
                Vector2 pos = new Vector2(-8, .23f);
                GameObject newNPC = Instantiate(NPCPrefab, pos, Quaternion.identity);
                int index = Random.Range(0, available.Count);
                newNPC.GetComponent<NPC>().SetupNPC(available[index]);
                ActiveJournals.Add(available[index]);
                available.RemoveAt(index);
            }
            journal.MatchGameNPCs = ActiveJournals;
        }
    }

    private void ResetMatches()
    {
        if(!journal.MatchGameReturn)
        {
            foreach(NPCJournal NPCJournal in NPCJournals)
            {
                foreach(MatchPair matchPair in NPCJournal.MatchingPair)
                {
                    matchPair.Matched = false;
                }
            }
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

    public Vector2 GetNewNPCPos(NPC npc)
    {
        Vector2 point = Vector2.zero;
        bool done = false;
        while (!done)
        {
            point = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 2f));
            done = true;
            foreach(BoxCollider2D bound in Bounds)
            {
                if (bound.OverlapPoint(point)) done = false;
            }
        }
        return point;
    }

}
