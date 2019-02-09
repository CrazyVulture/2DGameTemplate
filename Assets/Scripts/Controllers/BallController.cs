using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ball;

    float ballRange;

    public float timeLeft;

    void Start()
    {
        ballRange = UIMgr.Instance.GetScreenWidthRange(ball.transform);
        UpdateText();
        StartCoroutine(Spawn());
    }

    void FixedUpdate()
    {
        timeLeft-=Time.deltaTime;
        UpdateText(); 
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (timeLeft>0)
        {
            Vector3 position = new Vector3(
                                Random.Range(-ballRange, ballRange),
                                transform.position.y,
                                0.0f);

            Quaternion rotation = Quaternion.identity;
            Instantiate(ball, position, rotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
    }

    void UpdateText()
    {
        if (timeLeft<0)
            timeLeft=0;  
        UIMgr.Instance.SetTimeText(Mathf.RoundToInt(timeLeft));
    }

}
