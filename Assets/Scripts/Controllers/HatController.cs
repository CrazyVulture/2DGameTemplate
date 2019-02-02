using UnityEngine;

public class HatController : MonoBehaviour
{
    public Camera cam;
    public float speed = 1;

    Rigidbody2D rb;

    float maxWidth;

    void Start()
    {
        if (cam==null)
            cam = Camera.main;

        rb = GetComponent<Rigidbody2D>();

        //Set Max Width
        {
            Vector3 border = new Vector3(Screen.width, Screen.height, 0.0f);
            var hatFront = transform.Find("HatFront");
            float hatWidth = hatFront.GetComponent<SpriteRenderer>().bounds.extents.x;
            maxWidth = cam.ScreenToWorldPoint(border).x - hatWidth;
        }

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 rawPos = cam.ScreenToWorldPoint(Input.mousePosition);
        float widthRange = Mathf.Clamp(rawPos.x, -maxWidth, maxWidth);
        Vector3 targetPos = new Vector3(widthRange * speed, 0.0f, 0.0f);
        rb.MovePosition(targetPos);
    }
}
