using UnityEngine;
using UnityEngine.UI;

using JetBrains.Annotations;

public class UIMgr : Singleton<UIMgr>
{
    [NotNull]
    public Text scoreText;

    [NotNull]
    public Text timerText;

    [NotNull]
    public GameObject gameOverText;

    [NotNull]
    public GameObject RestartBtn;

    [NotNull]
    public GameObject SplashImg;

    [NotNull]
    public GameObject StartBtn;

    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetTimeText(int time)
    { 
        timerText.text="Time: "+time;
    }

    public void SetWinText()
    {
        EventMgr.Instance.WinGame();
    }

    public float GetScreenWidthRange(Transform targetObj)
    {
        Vector3 border = new Vector3(Screen.width, Screen.height, 0.0f);
        float objWidth = targetObj.GetComponent<SpriteRenderer>().bounds.extents.x;
        float screenWidth = Camera.main.ScreenToWorldPoint(border).x - objWidth;
        return screenWidth;
    }

    public void ShowGameOver(bool isRestart)
    {
        if (isRestart)
            RestartBtn.SetActive(true);
        else
            gameOverText.SetActive(true);
    }

    public void StartGameUI()
    {
        SplashImg.SetActive(false);
        StartBtn.SetActive(false);
    }
}
