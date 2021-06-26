using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingGame : MonoBehaviour
{
    public GameObject NPCPrefab;

    public NPCJournal[] journalNPCs;
    // Start is called before the first frame update
    void Start()
    {
        foreach(NPCJournal npc in journalNPCs)
        {
            Vector2 pos = new Vector2(0, 0);
            GameObject newNPC = Instantiate(NPCPrefab, pos, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
