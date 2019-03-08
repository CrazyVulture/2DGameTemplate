
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected Rigidbody2D rb;

    //Move 
    protected bool canMove;

    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = false;
    }

    public void ToggleControl(bool toggle)
    {
        canMove = toggle;
    }

}
