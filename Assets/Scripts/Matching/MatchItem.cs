using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchItem : SpriteTouch
{

    Vector2 BoardPos;
    Vector2 TouchOffset;

    protected override void MouseUP()
    {
        //transform.position = Vector2.MoveTowards(transform.position, BoardPos, Time.deltaTime);
        throw new System.NotImplementedException();
    }

    private void OnMouseDown()
    {
        TouchOffset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        BoardPos = transform.position;
        Debug.Log(BoardPos + "    boardpos  ");
        Debug.Log(TouchOffset + "   offset");
    }

    private void OnMouseDrag()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + TouchOffset);
        Vector2 currentPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(currentPos);
        transform.position = mousePos + TouchOffset;
        Debug.Log(Input.mousePosition + "  input");
        Debug.Log(mousePos + " mousepos");
        Debug.Log(currentPos + "  currentpos");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
