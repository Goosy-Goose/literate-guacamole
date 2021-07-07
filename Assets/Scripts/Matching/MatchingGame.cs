using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    public GameObject NPCPrefab;
    public NPCJournal[] NPCJournals;


    // Start is called before the first frame update
    void Start()
    {
       //foreach(NPCJournal npc in NPCJournals)
       for(int i=0; i<3; i+=1)
        { 
            Vector2 pos = new Vector2(-10, 3);
            GameObject newNPC = Instantiate(NPCPrefab, pos, Quaternion.identity);
            newNPC.AddComponent<NPC>();
        }
    }

    

        
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
