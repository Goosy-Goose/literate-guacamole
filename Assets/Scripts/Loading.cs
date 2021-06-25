using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{

    public Journal journal;
    public void LoadingButton(string sceneName)
    {
        journal.ReturnScene = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
