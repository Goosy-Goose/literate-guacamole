using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PageUI : MonoBehaviour
{
    public JournalUI JUI;
    public InputField inputFieldQ2, inputFieldQ3;
    public Text DateText;

    public RawImage Q1BH1, Q1BH2, Q1BH3, Q1BH4, Q1BH5;

    private void Start()
    {
        DateText.text = DateTime.Now.ToString("yyyy/MM/dd");
        Q1Button("none");
    }

    public void SubmitButton()
    {
        //todo: check for completed fields
        PageEntry page = new PageEntry();
        page.Answer1 = Q1Feeling;
        page.Answer2 = inputFieldQ2.text;
        page.Answer3 = inputFieldQ3.text;
        page.Date = DateText.text;
        JUI.SubmitPage(page);
    }

    public enum Q1Feelings
    {
        none,
        happy,
        sad,
        mad,
        neutral,
        stress
    }

    [SerializeField] Q1Feelings Q1Feeling;

    public void Q1Button(Q1Feelings feeling)
    {
        Q1Feeling = feeling;
    }

    public void Q1Button(string feeling)
    {
        Q1BH1.gameObject.SetActive(false);
        Q1BH2.gameObject.SetActive(false);
        Q1BH3.gameObject.SetActive(false);
        Q1BH4.gameObject.SetActive(false);
        Q1BH5.gameObject.SetActive(false);
        switch (feeling)
        {
            case "none":
                Q1Button(Q1Feelings.none);
                break;
            case "happy":
                Q1Button(Q1Feelings.happy);
                Q1BH1.gameObject.SetActive(true);
                break;
            case "sad":
                Q1Button(Q1Feelings.sad);
                Q1BH2.gameObject.SetActive(true);
                break;
            case "mad":
                Q1Button(Q1Feelings.mad);
                Q1BH3.gameObject.SetActive(true);
                break;
            case "stress":
                Q1Button(Q1Feelings.stress);
                Q1BH4.gameObject.SetActive(true);
                break;
            case "neutral":
                Q1Button(Q1Feelings.neutral);
                Q1BH5.gameObject.SetActive(true);
                break;
            
            default:
                Debug.LogWarning("Q1Button case missing: " + feeling);
                break;
        }

    }

    
}
