using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        EventMgr.Instance.Win();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(GameObject.FindGameObjectWithTag("Manager"));
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

}
