using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class DataCollection
{
    public static void WriteToFile(string data, string file)
    {
        if (Application.isEditor) file = "Assets/" + file;
        StreamWriter writer = new StreamWriter(file, true);
        writer.WriteLine(data);
        writer.Close();
    }
    public static void WriteToFile(string data, string file, bool append)
    {
        if (Application.isEditor) file = "Assets/" + file;
        StreamWriter writer = new StreamWriter(file, append);
        writer.WriteLine(data);
        writer.Close();
    }

    public static string ReadFile(string file)
    {
        string data = "";
        if (File.Exists(file))
        {
            StreamReader reader = new StreamReader(file);
            data = reader.ReadToEnd();
            reader.Close();
        }
        return data;
    }

    public static void SaveData(string data)
    {
        string path = "Resources/data.csv";
        data = DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc)).TotalSeconds + ", " + data;
        WriteToFile(data, path);
    }

    public static void MatchGameData(int score, bool completed)
    {
        SaveData($"Score, {score}, {completed}");
    }
    public static void MatchGameData(int duration)
    {
        SaveData($"Duration, {duration}");
    }

    public static void FeelingsData(bool feelingBefore, string feeling)
    {
        string header = "";
        if (feelingBefore)
        {
            header = "Emotion Before";
        }
        else
        {
            header = "Emotion After";
        }
        SaveData($"{header}, {feeling}");
    }
}
