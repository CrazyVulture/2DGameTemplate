using UnityEngine;
using UnityEngine.UI;

public class UFOController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb;
    private int count;

    public AudioClip collect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        SceneMgr.Instance.SetCountText(count);
    }

    //Update Physics effect before per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            ++count;
            SceneMgr.Instance.SetCountText(count);
        }
    }
}
