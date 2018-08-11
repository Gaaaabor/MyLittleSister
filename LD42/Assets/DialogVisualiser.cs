using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogVisualiser : MonoBehaviour
{
    public GameObject BottonLeft;
    public Text ButtonLeftText;
    public GameObject BottomRight;
    public Text BottomRightText;
    public GameObject TopLeft;
    public Text TopLeftText;
    public GameObject TopRight;
    public Text TopRightText;
    public GameObject Top;
    public Text TopText;


    public void UpdateDialogText(string text,DialogPlacement placement, bool clear)
    {
        if (clear)
        {
            BottonLeft.SetActive(false);
            BottomRight.SetActive(false);
            TopLeft.SetActive(false);
            TopRight.SetActive(false);
            Top.SetActive(false);
        }

        switch (placement)
        {
            case DialogPlacement.BottonLeft:
                BottonLeft.SetActive(true);
                ButtonLeftText.text = text;
                break;
            case DialogPlacement.BottomRight:
                BottomRight.SetActive(true);
                BottomRightText.text = text;
                break;
            case DialogPlacement.TopLeft:
                TopLeft.SetActive(true);
                TopLeftText.text = text;
                break;
            case DialogPlacement.TopRight:
                TopRight.SetActive(true);
                TopRightText.text = text;
                break;
            case DialogPlacement.Top:
                Top.SetActive(true);
                TopText.text = text;
                break;
            default:
                break;
        }
    }
}

[Serializable]
public enum DialogPlacement
{
    BottonLeft,
    BottomRight,
    TopLeft,
    TopRight,
    Top
}
