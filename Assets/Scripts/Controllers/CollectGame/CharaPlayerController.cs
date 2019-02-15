using UnityEngine;

public class CharaPlayerController : PlayerController
{
    //Animation
    Animator playerAnim;
    float lastX, lastY;

    void Start()
    {
        base.Init();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (UIMgr.Instance.score >= 1200)
        {
            EventMgr.Instance.WinGame();
            Destroy(GameObject.FindGameObjectWithTag("GameEnd"));
        }
        if (EventMgr.Instance.HitBomb)
        {
            EventMgr.Instance.HitBomb = false;
            EventMgr.Instance.LoseGame();
            Destroy(GameObject.FindGameObjectWithTag("GameEnd"));
        }
    }

    //Update Physics effect before per frame
    void FixedUpdate()
    {
        if (canMove)
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

    public void StayInPos()
    {
        rb.velocity = new Vector2(0.0f,0.0f);
        UpdateAnimation(new Vector3(0.0f, 0.0f, 0.0f));
    }
}
