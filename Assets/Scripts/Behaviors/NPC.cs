using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public float animSpeed = 0;

    GameObject NPCBody;


    // Start is called before the first frame update
    void Start()
    {
        //SetNewPos();
        Bubble.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!bubbleOpen)
        {
            HandleMovement();
        }
        else
        {
            animSpeed = 0;
        }
        HandleBubbleClose();
        SetZdepth();

    }

    private void Update()
    {
        GetComponent<Animator>().SetFloat("Speed", animSpeed);

    }

    void SetZdepth()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.y);
    }


    private void OnMouseDown()
    {
        if (FindObjectOfType<MatchingGame>())
        {
            Bubble.gameObject.SetActive(true);
            bubbleOpen = true;
            bubbleCloseTime = Time.fixedTime + bubbleCloseWait;
        }
        if(FindObjectOfType<Field>())
        {
            FindObjectOfType<Field>().LoadNPCJournalButton(journalIcon.NPCPage);
        }
        
    }

    void HandleMovement()
    {
        if (moveTime <= Time.fixedTime)
        {
            SetNewPos();
            moveTime = Time.fixedTime + waitTime;
        }
        Vector2 speedVec = (Vector2)transform.position - Vector2.MoveTowards(transform.position, point, speed * Time.deltaTime * slowed);
        animSpeed = speedVec.magnitude/Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, point, speed * Time.deltaTime * slowed);

        if(speedVec.x > 0)
        {
            NPCBody.GetComponent<SpriteRenderer>().flipX = true;
        }else if (speedVec.x < 0)
        {
            NPCBody.GetComponent<SpriteRenderer>().flipX = false;
        }
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
        if (SceneManager.GetActiveScene().name.Equals("Matching"))
        {
            point = FindObjectOfType<MatchingGame>().GetNewNPCPos(this);
            waitTime = Random.Range(7, 17);
            slowed = Random.Range(0.75f, 1.5f);
        }
        if (SceneManager.GetActiveScene().name.Equals("MainField"))
        {
            point = FindObjectOfType<Field>().GetNewNPCPos();
            waitTime = Random.Range(20, 37);
            slowed = Random.Range(0.75f, 1.5f);
        }
        
    }

    public void SetupNPC(NPCJournal npc)
    {
        if (SceneManager.GetActiveScene().name.Equals("Matching"))
        {
            journalIcon.SetNPCJournal(npc);
            GameObject[] matchingIcons = npc.GetMatchingIcons();
            if (matchingIcons[0])
            {
                Instantiate(matchingIcons[0], MatchingItem1);
            }
            if (matchingIcons[1])
            {
                Instantiate(matchingIcons[1], MatchingItem2);
            }
            NPCBody = Instantiate(npc.NPCBody, Body);
            NPCBody.transform.position = Body.position;
        }

        if (SceneManager.GetActiveScene().name.Equals("MainField"))
        {
            journalIcon.SetNPCJournal(npc);
            NPCBody = Instantiate(npc.NPCBody, Body);
            NPCBody.transform.position = Body.position;
        }
        
    }



}
