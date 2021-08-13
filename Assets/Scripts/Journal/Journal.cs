using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Journal", menuName = "Journal/Journal")]
public class Journal : ScriptableObject
{
    public List<PageEntry> pages = new List<PageEntry>();

    public List<PageEntry> pagePool = new List<PageEntry>();

    public List<NPCJournal> NPCPages = new List<NPCJournal>();
    public NPCJournal NPCPage;
    public bool PlayerJournal;
    public string ReturnScene;
    public List<NPCJournal> MatchGameNPCs;
    public List<MatchPair> ListOfShelfPlaces;
    public bool MatchGameReturn;



    public void AddPageEntry(PageEntry page)
    {
        if(pagePool.Count > 0)
        {
            PageEntry newPage = pagePool[0];
            pagePool.RemoveAt(0);
            newPage.Answer1 = page.Answer1;
            newPage.Answer2 = page.Answer2;
            newPage.Answer2 = page.Answer3;
            newPage.Date = page.Date;
            pages.Add(newPage);
        }
        else
        {
            Debug.LogError("pagePool is out of pages!");
        }
    }



}