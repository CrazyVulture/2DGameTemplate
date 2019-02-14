using UnityEngine;

public class Collect : MonoBehaviour
{
    public AudioClip collect;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            UIMgr.Instance.AddScore(100);       
        }     
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
            EventMgr.Instance.HitBomb = true;
    }
}
