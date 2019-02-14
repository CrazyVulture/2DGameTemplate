using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameController : MonoBehaviour
{

    public virtual void StartGame()
    {
        UIMgr.Instance.StartGameUI();
    }

    public virtual void EndGame(bool isWin)
    {
        if (isWin)
            UIMgr.Instance.SetGameOverText("You Win!");
        else
            UIMgr.Instance.SetGameOverText("Game Over!");
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
