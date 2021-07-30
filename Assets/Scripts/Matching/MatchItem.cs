using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : SpriteTouch
{

    Vector2 BoardPos;
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
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        int count = GetComponent<Collider2D>().OverlapCollider(filter, results);
        foreach(Collider2D result in results)
        { //result.GetComponent<NPC>().MatchingItem1.Equals(ItemType) || result.GetComponent<NPC>().MatchingItem2.Equals(ItemType)
            if (result.GetComponent<NPC>())
            {
                print("NPC Found: Check for matched item: " + result.GetComponent<NPC>().MatchingItem1.name);

            }
        }
        transform.position = BoardPos;
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
        transform.position = mousePos + TouchOffset;
    }

    // Start is called before the first frame update
    void Start()
    {
        BoardPos = transform.position;
    }

}
