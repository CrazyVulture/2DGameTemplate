using UnityEngine;

public abstract class PlayerController : BaseController
{
    //Have direction set?
    public bool hasDir = true;
    public float speed;

    protected float moveHorizontal;
    protected float moveVertical;

    protected Animator playerAnim;

    protected override void Init()
    {
        base.Init();
        playerAnim = GetComponent<Animator>();
        
    }

    protected void GetNormalAxis()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    protected void GetRawAxis()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }
}
