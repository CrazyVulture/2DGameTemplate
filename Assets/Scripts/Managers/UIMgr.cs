using UnityEngine;
using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    public Text scoreText;

    [HideInInspector]
    public int score = 0;

    public Text timerText;

    public Text overText;

    public GameObject gameOverText;

    public GameObject RestartBtn;

    public GameObject QuitBtn;

    public GameObject SplashImg;

    public GameObject StartBtn;

    public void AddScore(int deltaScore)
    {
        score += deltaScore;
        scoreText.text = "Score: " + score;
    }

    public void SetTimeText(int time)
    { 
        timerText.text="Time: "+time;
    }

    public void SetGameOverText(string text)
    {
        overText.text = text;
    }

    public float GetScreenWidthRange(Transform targetObj)
    {
        Vector3 border = new Vector3(Screen.width, Screen.height, 0.0f);
        float objWidth = targetObj.GetComponent<SpriteRenderer>().bounds.extents.x;
        float screenWidth = Camera.main.ScreenToWorldPoint(border).x - objWidth;
        return screenWidth;
    }

    public void ShowGameOver()
    {
        if (gameOverText && RestartBtn && QuitBtn)
        {
            gameOverText.SetActive(true);
            RestartBtn.SetActive(true);
            QuitBtn.SetActive(true);
        }
    }

    public void StartGameUI()
    {
        if (SplashImg && StartBtn)
        {
            SplashImg.SetActive(false);
            StartBtn.SetActive(false);
        }
    }
}
