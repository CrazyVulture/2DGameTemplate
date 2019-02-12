using UnityEngine;

public class Collect : MonoBehaviour
{
    int score=0;
    public AudioClip collect;

    void Start()
    {
         UIMgr.Instance.SetScoreText(score);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            score += 100;
            UIMgr.Instance.SetScoreText(score);
            if (score >= 1200)
                UIMgr.Instance.SetWinText();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            score -= 200;
            UIMgr.Instance.SetScoreText(score);
        }
    }
}
