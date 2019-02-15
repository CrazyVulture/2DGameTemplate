using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameController : MonoBehaviour
{
    public AudioClip bgmMusic;
    public AudioClip winSound;
    public AudioClip loseSound;

    public virtual void StartGame()
    {
        UIMgr.Instance.StartGameUI();
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    public virtual void EndGame(bool isWin)
    {
        if (isWin)
        {
            UIMgr.Instance.SetGameOverText("You Win!");
            SoundMgr.Instance.PlayMusic(winSound);
        }
        else
        {
            UIMgr.Instance.SetGameOverText("Game Over!");
            SoundMgr.Instance.PlayMusic(loseSound);
        }
            
        UIMgr.Instance.ShowGameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(GameObject.FindGameObjectWithTag("Manager"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
