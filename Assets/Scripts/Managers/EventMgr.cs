using UnityEngine;

public class EventMgr : Singleton<EventMgr>
{
    public bool isStart { get;private set; }
    bool isWin;
    bool isRestart;
    bool isQuit;
    bool isLose;

    [HideInInspector]
    public bool HitBomb;

    public GameController gameController;

    public AudioClip bgmMusic;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Start()
    {
        isStart = isWin = isRestart = isLose = isQuit = false;
    }

    void Update()
    {
        //Start
        if (isStart)
        {
            SoundMgr.Instance.PlayMusic(bgmMusic, true);
            gameController.StartGame();
            isStart = false;
        }
        //Win
        if (isWin)
        {
            SoundMgr.Instance.PlayMusic(winSound);
            gameController.EndGame(true);
            isWin = false;
        }
        //Lose
        if (isLose)
        {
            SoundMgr.Instance.PlayMusic(loseSound);
            gameController.EndGame(false);
            isLose = false;
        }
        //Restart
        if (isRestart)
        {
            gameController.RestartGame();
            isRestart = false;
        }
        //Quit
        if (isQuit)
        {
            gameController.QuitGame();
            isQuit = false;
        }
    }

    public void StartGame()
    {
        isStart = true;
    }

    public void WinGame()
    {
        isWin = true;
    }

    public void LoseGame()
    {
        isLose = true;
    }

    public void RestartGame()
    {
        isRestart = true;
    }

    public void QuitGame()
    {
        isQuit = true;
    }
}
