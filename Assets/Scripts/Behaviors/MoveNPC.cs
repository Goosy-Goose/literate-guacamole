using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour //ADD A CHECK TO SEE IF THINGS ARE OVERLAPPING (how???)
{
    [SerializeField] private float speed = 1;
    [SerializeField] private Vector2 point;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        point = new Vector2(Random.Range(-8,8), 3);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;

        transform.position = Vector2.MoveTowards(transform.position, point, t/15);

        if (t >= 10)
        {
            point = new Vector2(Random.Range(-8, 6), Random.Range(-3, 3));
            t = 0;
        }
    }
}
