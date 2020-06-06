using UnityEngine;

using Pixelplacement;

public class UIBox : MonoBehaviour
{
    public AnimationCurve curve1;
    public float tweenTime;

    public Vector2 hiddenPos;
    public Vector2 shownPos;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public enum BoxState
    {
        Shown,
        Hidden
    }

    private BoxState thisBoxState = BoxState.Hidden;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (thisBoxState == BoxState.Hidden)
    //        {
    //            ShowBox();
    //        }

    //        else if (thisBoxState == BoxState.Shown)
    //        {
    //            HideBox();
    //        }
    //    }
    //}

    public void HideBox()
    {
        if (thisBoxState == BoxState.Hidden)
        {
            return;
        }

        Tween.AnchoredPosition(rectTransform, hiddenPos, tweenTime, 0f, curve1);

        thisBoxState = BoxState.Hidden;
    }

    public void ShowBox()
    {
        if (thisBoxState == BoxState.Shown)
        {
            return;
        }

        Tween.AnchoredPosition(rectTransform, shownPos, tweenTime, 0f, curve1);

        thisBoxState = BoxState.Shown;
    }
}