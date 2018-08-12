using UnityEngine;
using UnityEngine.UI;

public class DialogVisualiser : SingletonBase<DialogVisualiser>
{
    public GameObject BottonLeft;
    public Text ButtonLeftText;
    public Text ButtonLeftOwner;
    public GameObject BottomRight;
    public Text BottomRightText;
    public Text BottomRightOwner;
    public GameObject TopLeft;
    public Text TopLeftText;
    public Text TopLeftOwner;
    public GameObject TopRight;
    public Text TopRightText;
    public Text TopRightOwner;
    public GameObject Top;
    public Text TopText;
    public Text TopOwner;

    public GameObject UI;

    private void Awake()
    {
        ClearDialog();
    }

    public void UpdateDialogText(string text, string owner, DialogPlacement placement, bool clear, bool isModal)
    {
        if (isModal)
        {
            UI.SetActive(false); 
        }
        else
        {
            UI.SetActive(true);
        }

        if (clear)
        {
            ClearDialog();
        }
        
        switch (placement)
        {
            case DialogPlacement.BottomLeft:
                BottonLeft.SetActive(true);
                ButtonLeftText.text = text;
                ButtonLeftOwner.text = owner;
                break;
            case DialogPlacement.BottomRight:
                BottomRight.SetActive(true);
                BottomRightText.text = text;
                BottomRightOwner.text = owner;
                break;
            case DialogPlacement.TopLeft:                
                TopLeft.SetActive(true);
                TopLeftText.text = text;
                TopLeftOwner.text = owner;
                break;
            case DialogPlacement.TopRight:
                TopRight.SetActive(true);
                TopRightText.text = text;
                TopRightOwner.text = owner;
                break;
            case DialogPlacement.Top:
                Top.SetActive(true);
                TopText.text = text;
                TopOwner.text = owner;
                break;
            default:
                break;
        }
    }

    public void EndDialog()
    {
        ClearDialog();
        UI.SetActive(true);
    }

    public void ClearDialog()
    {
        BottonLeft.SetActive(false);
        BottomRight.SetActive(false);
        TopLeft.SetActive(false);
        TopRight.SetActive(false);
        Top.SetActive(false);
    }
}

public enum DialogPlacement
{
    BottomLeft,
    BottomRight,
    TopLeft,
    TopRight,
    Top,
    None
}
