using UnityEngine;

public class EventMgr : Singleton<EventMgr>
{
    public AudioClip bgmMusic;
    public AudioClip winSound;

    private bool isWin=false;

    void Start()
    {
        GameInit();
    }

    void Update()
    {
        if (isWin)
            WinAction();
    }

    //Game Init
    private void GameInit()
    {
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    //Win part
    public void Win()
    {
        isWin = true;
    }
    private void WinAction()
    {
        SoundMgr.Instance.PlayMusic(winSound);
        isWin = false;
    }
}
