using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowHandler : MonoBehaviour
{
    public static WindowHandler Singleton;
    // Start is called before the first frame update
    void Start()
    {
        if (!Singleton)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

}
