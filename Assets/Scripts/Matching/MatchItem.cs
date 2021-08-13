using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : SpriteTouch
{

    Vector3 BoardPos;
    Vector2 TouchOffset;

    public enum ItemTypes
    {
        Book,
        Flower,
        Sunglasses,
        Mushroom,
        Necklace,
        Candy,
        Strawberry,
        Bow,
        Ribbon,
        Violin,
        Seashell,
        Basil
    }
    public ItemTypes ItemType;

    protected override void MouseUP()
    {
        bool matched = false;
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        int count = GetComponent<Collider2D>().OverlapCollider(filter, results);
        foreach(Collider2D result in results)
        { 
            if (result.GetComponent<NPC>())
            {
                NPC npc = result.GetComponent<NPC>();
                if (npc.MatchingItem1.GetComponentInChildren<MatchingIcon>())
                {
                    if (npc.MatchingItem1.GetComponentInChildren<MatchingIcon>().ItemType == ItemType)
                    {
                        print($"{ItemType} Found MatchingItem 1");
                        CheckItemMatch(npc);
                        npc.MatchingItem1.GetComponentInChildren<MatchingIcon>().Match();
                        matched = true;
                    }

                }
                if (npc.MatchingItem2.GetComponentInChildren<MatchingIcon>())
                {
                    if (npc.MatchingItem2.GetComponentInChildren<MatchingIcon>().ItemType == ItemType)
                    {
                        print($"{ItemType} Found MatchingItem 2");
                        CheckItemMatch(npc);
                        npc.MatchingItem2.GetComponentInChildren<MatchingIcon>().Match();
                        matched = true;

                    }
                }
                
            }
            else
            {
                print($"{ItemType} Item not found");
            }
        }
        if (matched)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = BoardPos;
        }
    }

    private void CheckItemMatch(NPC npc)
    {
        foreach (MatchPair matchPair in npc.journalIcon.NPCPage.MatchingPair)
        {
            if (matchPair.Name.Equals(ItemType.ToString()))
            {
                matchPair.Matched = true;
            }
        }
    }

    private void OnMouseDown()
    {
        TouchOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    private void OnMouseDrag()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + TouchOffset);
        Vector2 currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(currentPos);
        transform.position = (Vector3)(mousePos + TouchOffset) + Vector3.forward*(-9);
    }

    // Start is called before the first frame update
    void Start()
    {
        BoardPos = transform.position;
    }

}
