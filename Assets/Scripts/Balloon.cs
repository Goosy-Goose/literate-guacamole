using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private bool popped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        poppingStart();
    }

    private void poppingStart()
    {
        if (!popped)
        {
            GetComponent<Animator>().SetTrigger("Pop");
            popped = true;
        }
        
    }

    public void PopCompleted()
    {
        Destroy(gameObject);
    }
    

}
