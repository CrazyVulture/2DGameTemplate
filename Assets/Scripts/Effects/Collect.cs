using UnityEngine;

public class Collect : MonoBehaviour
{
    int score=0;
    public AudioClip collect;

    void Start()
    {
         UIMgr.Instance.SetCountText(score);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            score += 100;
            UIMgr.Instance.SetCountText(score);
            if (score >= 1200)
                UIMgr.Instance.SetWinText();
        }
    }
}
