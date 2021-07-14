using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    public GameObject NPCPrefab;
    public NPCJournal[] NPCJournals;
    List<NPCJournal> ActiveJournals = new List<NPCJournal>();

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
        List<NPCJournal> available = Utility.GetList<NPCJournal>(NPCJournals);
        for (int i = 0; i < 3; i += 1)
        {
            Vector2 pos = new Vector2(-10, 3);
            GameObject newNPC = Instantiate(NPCPrefab, pos, Quaternion.identity);
            int index = Random.Range(0, available.Count);
            newNPC.GetComponentInChildren<NPCJournalIcon>().NPCPage = available[index];
            available.RemoveAt(index);
            
        }
    }


}
