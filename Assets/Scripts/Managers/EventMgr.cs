using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMgr : Singleton<EventMgr>
{
    bool isStart;
    public BallController ballController;
    public HatController hatController;

    public AudioClip bgmMusic;

    bool isWin;
    public AudioClip winSound;

    bool isRestart;

    void Start()
    {
        GameInit();
    }

    void Update()
    {
        //Start
        if (isStart)
        {
            UIMgr.Instance.StartGameUI();
            hatController.ToggleControl(true);
            isStart = false;
        }
        //Win
        if (isWin)
        {
            SoundMgr.Instance.PlayMusic(winSound);
            isWin = false;
        }
        //Restart
        if (isRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(GameObject.FindGameObjectWithTag("Manager"));
            isRestart = false;
        }
    }

    //Game Init
    void GameInit()
    {
        isStart = false;
        isWin = false;
        isRestart = false;
        //Play bgm
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    //Start
    public void StartGame()
    {
        isStart = true;
        StartCoroutine(ballController.Spawn());
    }

    //Win
    public void WinGame()
    {
        isWin = true;
    }

    //Restart
    public void RestartGame()
    {
        isRestart = true;
    }

}
