using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour //ADD A CHECK TO SEE IF THINGS ARE OVERLAPPING (how???)
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 point;
    float t;
    float waitTime;
    float slowed;

    public Transform MatchingItem1, MatchingItem2, Body;
    public NPCJournalIcon journalIcon;


    // Start is called before the first frame update
    void Start()
    {
        point = new Vector2(Random.Range(-8,6), Random.Range(-3, 3));
        waitTime = Random.Range(7, 17);
        slowed = Random.Range(15, 25);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;

        transform.position = Vector2.MoveTowards(transform.position, point, t/slowed);

        if (t >= waitTime)
        {
            point = new Vector2(Random.Range(-8, 6), Random.Range(-3, 3));
            waitTime = Random.Range(7, 17);
            t = 0;
        }

        SetZdepth();
    }

    void SetZdepth()
    {
        Vector3 pos = transform.position;
        float offset = 0;
        transform.position = new Vector3(pos.x, pos.y, pos.y + offset);
    }

    public void SetupNPC(NPCJournal npc)
    {
        journalIcon.SetNPCJournal(npc);
        GameObject[] matchingIcons = npc.GetMatchingIcons();
        GameObject icon1 = Instantiate(matchingIcons[0], MatchingItem1);
        GameObject icon2 = Instantiate(matchingIcons[1], MatchingItem2);
        GameObject NPCBody = Instantiate(npc.NPCBody, Body);
    }

}
