using UnityEngine;

public class CharaController : MonoBehaviour
{
    //Speed
    Rigidbody2D rb;
    public float speed = 10f;

    //Have direction set?
    public bool hasDir = true;

    //Animation
    Animator playerAnim;
    float lastX, lastY;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    //Update Physics effect before per frame
    void FixedUpdate()
    {
        Move();
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
