using UnityEngine;


public class EventMgr : Singleton<EventMgr>
{
    public AudioClip bgmMusic;
    bool isWin = false;
    public AudioClip winSound;

    void Start()
    {
        GameInit();
    }

    void Update()
    {
        //Win Event
        if (isWin)
        {
            SoundMgr.Instance.PlayMusic(winSound);
            isWin = false;
        }
    }

    //Game Init
    void GameInit()
    {
        //Play bgm
        SoundMgr.Instance.PlayMusic(bgmMusic, true);
    }

    //Win
    public void Win()
    {
        isWin = true;
    }
    
}
