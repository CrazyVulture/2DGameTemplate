using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;

    public AudioClip explodeSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            SoundMgr.Instance.PlaySound(explodeSound);
            Destroy(gameObject);
        }
    }

}
