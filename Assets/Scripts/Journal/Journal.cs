using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Journal", menuName = "Journal/Journal")]
public class Journal : ScriptableObject
{
    //public List<PageEntry> pages = new List<PageEntry>();
    public PageEntries pageEntries;
    public List<PageEntry> pages { get { return pageEntries.pages; } }
    public string JournalJSONPath = "Resources/journal1.txt";
    public TextAsset JsonFile;

    //public List<PageEntry> pagePool = new List<PageEntry>();

    public List<NPCJournal> NPCPages = new List<NPCJournal>();
    public NPCJournal NPCPage;
    public bool PlayerJournal;
    public string ReturnScene;
    public List<NPCJournal> MatchGameNPCs;
    public List<MatchPair> ListOfShelfPlaces;
    public bool MatchGameReturn;

    private void Awake()
    {
        string jsonJournal = GetFile(JournalJSONPath);
        pageEntries = JsonUtility.FromJson<PageEntries>(jsonJournal);
    }

    public void AddPageEntry(PageEntry page)
    {
        PageEntry newPage = new PageEntry();

        newPage.Answer1 = page.Answer1;
        newPage.Answer2 = page.Answer2;
        newPage.Answer3 = page.Answer3;
        newPage.Date = page.Date;
        pageEntries.pages.Add(newPage);
        string jsonJournal = JsonUtility.ToJson(pageEntries, true);
        DataCollection.WriteToFile(jsonJournal, JournalJSONPath, false);
    }

    public static string GetFile(string name)
    {
        string path = (Application.isEditor)?  "Assets/"  + name:  name;
        StreamReader reader = new StreamReader(path);

        string contents = reader.ReadToEnd();
        return contents;
    }

}