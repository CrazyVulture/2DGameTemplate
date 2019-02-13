using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GAMETYPE
    {
        COLLECT_GAME = 0,
        CATCHER_GAME
    };

    public GAMETYPE gameType;

    [CanBeNull]
    public CharaController charaController;
    [CanBeNull]
    public BallController ballController;
    [CanBeNull]
    public HatController hatController;

    public void StartGame()
    {
        UIMgr.Instance.StartGameUI();

        switch (gameType)
        {
            case GAMETYPE.COLLECT_GAME:
                charaController.ToggleControl(true);
                break;
            case GAMETYPE.CATCHER_GAME:
                hatController.ToggleControl(true);
                StartCoroutine(ballController.Spawn());
                break;
        }
        
    }

    public void EndGame(bool isWin)
    {
        if (isWin)
            UIMgr.Instance.SetGameOverText("You Win!");
        else
            UIMgr.Instance.SetGameOverText("Game Over!");
        switch (gameType)
        {
            case GAMETYPE.COLLECT_GAME:
                charaController.ToggleControl(false);
                charaController.StayInPos();
                break;
            case GAMETYPE.CATCHER_GAME:
                hatController.ToggleControl(false);
                break;
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
