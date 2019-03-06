using UnityEngine;

public abstract class PlayerController : BaseController
{
    //Have direction set?
    public bool hasDir = true;

    protected Animator playerAnim;

    protected override void Init()
    {
        base.Init();
        playerAnim = GetComponent<Animator>();
    }
}
