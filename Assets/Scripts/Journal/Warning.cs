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

    public void ClosePanelButton()
    {
        closePanel();
    }

    public bool setWarning(PageEntry page)
    {
        bool success = false;
        if (page.Answer1.ToString().Equals("none"))
        {
            WarningPanel.SetActive(true);
            WarningText.text ="Please answer Question 1";
        } else if (page.Answer2.Equals(""))
        {
            WarningPanel.SetActive(true);
            WarningText.text = "Please answer Question 2";
        } else if (page.Answer3.Equals(""))
        {
            WarningPanel.SetActive(true);
            WarningText.text = "Please answer Question 3";
        }
        else
        {
            success = true;
        }

        return success;
    }
}
