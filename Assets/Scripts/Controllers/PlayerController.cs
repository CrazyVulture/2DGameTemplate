using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed
    private Rigidbody2D rb;
    public float speed = 10;

    //Player direction
    public bool hasDir = true;
    public enum FACEDIR
    {
        DOWN=0,
        RIGHT,
        UP,
        LEFT
    };
    private FACEDIR faceDir = FACEDIR.DOWN;

    //Animation
    Animator playerAnim;

    //Collect action
    private int count;
    public AudioClip collect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        count = 0;
        UIMgr.Instance.SetCountText(count);
    }

    //Update Physics effect before per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        playerAnim.SetFloat("SpeedY", Mathf.Abs(moveVertical));
        playerAnim.SetFloat("SpeedX", Mathf.Abs(moveHorizontal));

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        if (hasDir)
        {
            rb.velocity = movement * speed;
            if (moveHorizontal > 0)
                faceDir = FACEDIR.RIGHT;
            if (moveHorizontal < 0)
                faceDir = FACEDIR.LEFT;
            if (moveVertical > 0)
                faceDir = FACEDIR.UP;
            if (moveVertical < 0)
                faceDir = FACEDIR.DOWN;
            ChangeDir();
        }
        else
            rb.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            SoundMgr.Instance.PlaySound(collect);
            other.gameObject.SetActive(false);
            ++count;
            UIMgr.Instance.SetCountText(count);
            if (count >= 12)
                EventMgr.Instance.Win();
        }
    }

    void ChangeDir()
    {
        switch (faceDir)
        {
            case FACEDIR.DOWN:
                playerAnim.SetInteger("Direction", 0);
                break;
            case FACEDIR.RIGHT:
                playerAnim.SetInteger("Direction", 1);
                break;
            case FACEDIR.UP:
                playerAnim.SetInteger("Direction", 2);
                break;
            case FACEDIR.LEFT:
                playerAnim.SetInteger("Direction", 3);
                break;
        }
    }

}
