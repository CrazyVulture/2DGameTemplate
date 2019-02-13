using UnityEngine;

public class Collect : MonoBehaviour
{
    public AudioClip collect;

    GameController.GAMETYPE tempGameType;

    void Start()
    {
        tempGameType = EventMgr.Instance.GetGameType();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            UIMgr.Instance.AddScore(100);
            if (tempGameType == GameController.GAMETYPE.COLLECT_GAME && UIMgr.Instance.score >= 1200)
            {
                EventMgr.Instance.WinGame();
                Destroy(GameObject.FindGameObjectWithTag("GameEnd"));
            }
                    
        }     
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            switch (tempGameType)
            {
                case GameController.GAMETYPE.COLLECT_GAME:
                    EventMgr.Instance.LoseGame();
                    Destroy(GameObject.FindGameObjectWithTag("GameEnd"));
                    break;
                case GameController.GAMETYPE.CATCHER_GAME:
                    UIMgr.Instance.AddScore(-200);
                    break;
            }
        }
    }
}
