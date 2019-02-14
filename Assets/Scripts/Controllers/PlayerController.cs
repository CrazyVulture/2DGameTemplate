using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    //Speed
    public float speed;
    protected Rigidbody2D rb;

    //Move 
    protected bool canMove;

    //Have direction set?
    public bool hasDir = true;

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
