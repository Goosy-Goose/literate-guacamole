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
        List<GameObject> items = GetItemsToMatch();
        //for(int i=0; i<NPCJournal.Count; i += 1)
        {

        }
        /*List<GameObject> items = GetItemsToMatch();
        for(int i=0; i<NPCJournals.Length; i += 1)
        {
            foreach(MatchPair pair in NPCJournals[i].MatchingPair)
            {

            }
            Transform shelf = shelfItem[i];
            if ()
            {
                GameObject item = Instantiate(items[i], shelf.position, Quaternion.identity);
            }
            //else
            {
                //GameObject item = Instantiate(new GameObject(), shelf.position, Quaternion.identity);
            }
            
        }*/

        List<GameObject> listOfShelfPlaces = new List<GameObject>(); //index Transform[] shelfItem; (same size, use this list to instantiate items) size 5 [0,1,2, -3, -6]
        List<int> listOfNPCItemsIndex = new List<int>(); //index MatchingItems[] ActiveJournals.MatchingItems [0,1,2]
        List<GameObject> listOfNPCItems = new List<GameObject>();
        List<int> ListOfExtraNPCItemsIndex = new List<int>(); // index MatchingItems[] NPCJournals.MatchingItems - listOfNPCItems [-1, -2, -3, -4, -5, -6]
        List<GameObject> ListOfExtraNPCItems = new List<GameObject>();

        foreach (NPCJournal npc in ActiveJournals)
        {
            foreach (MatchPair matchPair in npc.MatchingPair)
            {
                listOfNPCItems.Add(matchPair.Item);
            }
        }

        //populate the listOfExtraNPCItmes
        foreach(NPCJournal NPCJournal in NPCJournals)
        {
            foreach(MatchPair matchPair in NPCJournal.MatchingPair)
            {
                if (!listOfNPCItems.Contains(matchPair.Item))
                {
                    ListOfExtraNPCItems.Add(matchPair.Item);
                }
                
            }
        }

        while(listOfShelfPlaces.Count < shelfItem.Length && listOfNPCItems.Count > 0)
        {
            listOfShelfPlaces.Add(listOfNPCItems[0]);
            listOfNPCItems.RemoveAt(0);
        }
        while (listOfShelfPlaces.Count < shelfItem.Length && ListOfExtraNPCItems.Count > 0)
        {
            listOfShelfPlaces.Add(ListOfExtraNPCItems[0]);
            ListOfExtraNPCItems.RemoveAt(0);
        }
        //listOfShelfPlaces.Shuffle() just shuffle the list
        
        for(int i=0; i<listOfShelfPlaces.Count; i += 1)
        {
            GameObject item = Instantiate(listOfShelfPlaces[i], shelfItem[i]);
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
            point = new Vector2(Random.Range(-10, 10), Random.Range(-10, 2));
            done = true;
            foreach(BoxCollider2D bound in Bounds)
            {
                if (bound.OverlapPoint(point)) done = false;
            }
        }
        return point;

        /*Vector2 point = new Vector2(Random.Range(-6, 7), Random.Range(-3, 2));
        if(!Bounds[0].OverlapPoint(point))
        {
            point = new Vector2(Random.Range(-6, 8), Random.Range(-3, 2));
        }
        return point;*/
    }

}
