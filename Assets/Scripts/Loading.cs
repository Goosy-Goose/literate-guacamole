using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public Journal journal;
    public bool PlayerJournal;
    public NPCJournal NPCPage;

    public void LoadingButton(string sceneName)
    {
        journal.ReturnScene = SceneManager.GetActiveScene().name;
        if (PlayerJournal)
        {
            journal.PlayerJournal = true;
        }
        else
        {
            journal.PlayerJournal = false;
            journal.PlayerJournal = false;
            journal.NPCPage = NPCPage;
        }
        
        if(sceneName == "MainField" && FindObjectOfType<MatchingGame>())
        {
            FindObjectOfType<MatchingGame>().OnExit();
        }
        SceneManager.LoadScene(sceneName);
    }
}
