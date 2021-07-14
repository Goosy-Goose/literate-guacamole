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
    

    public static List<T> GetList<T>(T[] array)
    {
        List<T> list = new List<T>();
        for(int i=0; i<array.Length; i += 1)
        {
            list.Add(array[i]);
        }
        return list;
    }

}
