using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour //ADD A CHECK TO SEE IF THINGS ARE OVERLAPPING (how???)
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 point;
    float moveTime;
    float waitTime;
    float slowed;
    bool bubbleOpen = false;
    float bubbleCloseTime = float.NegativeInfinity;
    float bubbleCloseWait = 5;

    public Transform MatchingItem1, MatchingItem2, Body, Bubble;
    public NPCJournalIcon journalIcon;



    // Start is called before the first frame update
    void Start()
    {
        SetNewPos();
        Bubble.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!bubbleOpen)
        {
            HandleMovement();
        }
        HandleBubbleClose();
        SetZdepth();
    }

    void SetZdepth()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.y);
    }


    private void OnMouseDown()
    {
        
        Bubble.gameObject.SetActive(true);
        bubbleOpen = true;
        bubbleCloseTime = Time.fixedTime + bubbleCloseWait;
    }

    void HandleMovement()
    {
        if (moveTime <= Time.fixedTime)
        {
            SetNewPos();
            moveTime = Time.fixedTime + waitTime;
        }
        transform.position = Vector2.MoveTowards(transform.position, point, speed * Time.deltaTime * slowed);
    }



    void HandleBubbleClose()
    {

        if (bubbleOpen && bubbleCloseTime <=Time.fixedTime)
        {
            bubbleOpen = false;
            Bubble.gameObject.SetActive(false);
        }
    }

    void SetNewPos()
    {
        point = FindObjectOfType<MatchingGame>().GetNewNPCPos(this);
        waitTime = Random.Range(7, 17);
        slowed = Random.Range(0.75f, 1.5f);
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
