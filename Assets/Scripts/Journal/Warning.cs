using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    public JournalUI JUI;
    public GameObject WarningPanel;
    public Text WarningText;
    // Start is called before the first frame update
    void Start()
    {
        ClosePanel();
    }

    void ClosePanel()
    {
        WarningPanel.SetActive(false);
    }

    public void ClosePanelButton()
    {
        ClosePanel();
    }

    public bool SetWarning(PageEntry page)
    {
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
            return true;
        }
        return false;
    }
}
