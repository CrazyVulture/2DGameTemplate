using UnityEngine;

public class HatController : MonoBehaviour
{
    
    public float speed = 1;

    Rigidbody2D rb;

    float hatRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hatRange = UIMgr.Instance.GetScreenWidthRange(transform.Find("HatFront"));
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var mouseRange = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -hatRange, hatRange);
        Vector3 targetPos = new Vector3(mouseRange * speed, 0.0f, 0.0f);
        rb.MovePosition(targetPos);
    }
}
