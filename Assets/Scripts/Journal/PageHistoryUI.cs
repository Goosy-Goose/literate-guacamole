using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageHistoryUI : MonoBehaviour
{
    public Text DateText, A2Text, A3Text;
    
    [System.Serializable]
    public struct FeelingIcon
    {
        public GameObject[] items;
    }
    public FeelingIcon[] FeelingIcons = new FeelingIcon[5];

    public void LoadPage(PageEntry page)
    {
        DateText.text = page.Date;
        A2Text.text = page.Answer2;
        A3Text.text = page.Answer3;
        setFeelingIcons(page.Answer1);
    }

    private void setFeelingIcons(PageUI.Q1Feelings feeling)
    {
        //set all icons to false
        for(int i = 0; i < FeelingIcons.Length; i+=1)
        {
            setFeelingIcon(i, false);
        }

        switch (feeling)
        {
            case PageUI.Q1Feelings.happy:
                setFeelingIcon(0, true);
                break;
            case PageUI.Q1Feelings.sad:
                setFeelingIcon(1, true);
                break;
            case PageUI.Q1Feelings.neutral:
                setFeelingIcon(2, true);
                break;
            case PageUI.Q1Feelings.mad:
                setFeelingIcon(3, true);
                break;
            case PageUI.Q1Feelings.stress:
                setFeelingIcon(4, true);
                break;
            default:
                Debug.LogWarning("Saved feeling case missing: " + feeling);
                break;
        }
    }

    private void setFeelingIcon(int index, bool on)
    {
        foreach(GameObject icon in FeelingIcons[index].items)
        {
            icon.SetActive(on);
        }
    }
}
