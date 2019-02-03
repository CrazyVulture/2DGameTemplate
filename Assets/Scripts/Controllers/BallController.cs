using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ball;
    public float startTime=2.0f;
    public float minTime = 1.0f;
    public float maxTime = 2.0f;

    float ballRange;

    void Start()
    {
        ballRange = UIMgr.Instance.GetScreenWidthRange(ball.transform);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            Vector3 position = new Vector3(
                                Random.Range(-ballRange, ballRange),
                                transform.position.y,
                                0.0f);

            Quaternion rotation = Quaternion.identity;
            Instantiate(ball, position, rotation);
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }

}
