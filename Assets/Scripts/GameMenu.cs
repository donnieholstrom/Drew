using UnityEngine;

using Pixelplacement;

public class GameMenu : MonoBehaviour
{
    // private bool paused = false;

    public CanvasGroup gameMenu;

    public AnimationCurve fadeInCurve;
    public AnimationCurve fadeOutCurve;

    private void Awake()
    {
        gameMenu.alpha = 0f;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (!paused)
        //    {
        //        Tween.CanvasGroupAlpha(gameMenu, 1f, 0.5f, 0f, fadeInCurve);

        //        // Time.timeScale = 0f;
        //        paused = true;
        //    }
            
        //    else
        //    {
        //        Tween.CanvasGroupAlpha(gameMenu, 0f, 0.5f, 0f, fadeOutCurve);

        //        // Time.timeScale = 1f;
        //        paused = false;

        //    }
        //}
    }
}