using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Utility
{
    public static string GetDate()
    {
        return DateTime.Now.ToString("MM/dd/yyyy");
    }
    /*
    public static void Placeholder()
    {
        PageEntryPanel.gameObject.SetActive(false);
        PageHistoryPanel.gameObject.SetActive(true);
        PageHistoryPanel.LoadPage(journal.pages[journal.pages.Count - 1]);
    }*/

}
