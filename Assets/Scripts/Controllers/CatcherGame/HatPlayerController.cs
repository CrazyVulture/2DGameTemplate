using UnityEngine;

public class HatPlayerController : PlayerController
{
    float hatRange;
    
    void Start()
    {
        base.Init();
        hatRange = UIMgr.Instance.GetScreenWidthRange(transform.Find("HatFront"));
    }

    void Update()
    {
        if (EventMgr.Instance.HitBomb)
        {
            EventMgr.Instance.HitBomb = false;
            UIMgr.Instance.AddScore(-200);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
            Move();
    }

    void Move()
    {
        var mouseRange = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -hatRange, hatRange);
        Vector3 targetPos = new Vector3(mouseRange * speed, 0.0f, 0.0f);
        rb.MovePosition(targetPos);
    }

}
