using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingIcon : MonoBehaviour
{
    public MatchItem.ItemTypes ItemType;
    

    public void Match()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
