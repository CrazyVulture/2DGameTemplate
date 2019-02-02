using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Speed
    Rigidbody2D rb;
    public float speed = 10f;

    //Have direction set?
    public bool hasDir = true;

    //Animation
    Animator playerAnim;
    float lastX, lastY;

    //Collect action
    int count;
    public AudioClip collect;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        UIMgr.Instance.SetCountText(count);
    }

    //Update Physics effect before per frame
    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            PickUp(other);
        }
    }

    void Move()
    {
        if (hasDir)
        {
            Vector3 rightMove = Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
            Vector3 upMove = Vector3.up * speed * Time.deltaTime * Input.GetAxis("Vertical");
            Vector3 heading = Vector3.Normalize(rightMove + upMove);

            Vector2 movement = new Vector2(rightMove.x + upMove.x, rightMove.y + upMove.y);

            rb.velocity = movement*speed*5.0f;

            UpdateAnimation(heading);
        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.AddForce(movement * speed);
        }
    }

    void PickUp(Collider2D other)
    {
        SoundMgr.Instance.PlaySound(collect);
        other.gameObject.SetActive(false);
        count++;
        UIMgr.Instance.SetCountText(count);
        if (count >= 12)
            EventMgr.Instance.Win();
    }

    void UpdateAnimation(Vector3 dir)
    {
        //Play Idle
        if (dir.x==0 && dir.y==0)
        {
            playerAnim.SetFloat("LastDirX", lastX);
            playerAnim.SetFloat("LastDirY", lastY);
            playerAnim.SetBool("Movement", false);
        }
        //Play move
        else
        {
            lastX = dir.x;
            lastY = dir.y;
            playerAnim.SetBool("Movement", true);
        }

        playerAnim.SetFloat("DirX", dir.x);
        playerAnim.SetFloat("DirY", dir.y);
    }
}
