using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    public GameObject WarningPanel;
    public Text WarningText;
    // Start is called before the first frame update
    void Start()
    {
        closePanel();
    }
    void closePanel()
    {
        WarningPanel.SetActive(false);
    }
  
    public void SetWarning(string message)
    {
        //activate panel and set message to warningText
    }
}
