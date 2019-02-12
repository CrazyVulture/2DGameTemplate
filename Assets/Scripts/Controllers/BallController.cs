using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject[] balls;

    float ballRange;

    public float timeLeft;

    bool isStart;

    void Start()
    {
        isStart = false;
        ballRange = UIMgr.Instance.GetScreenWidthRange(balls[0].transform);
        UpdateText();
    }

    void FixedUpdate()
    {
        if (isStart)
        {
            timeLeft -= Time.deltaTime;
            UpdateText();
        }
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        isStart = true;
        while (timeLeft>0)
        {
            SpawnItems();
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
        yield return new WaitForSeconds(2.0f);
        UIMgr.Instance.ShowGameOver(false);
        yield return new WaitForSeconds(2.0f);
        UIMgr.Instance.ShowGameOver(true);
    }

    void UpdateText()
    {
        if (timeLeft<0)
            timeLeft = 0;

        UIMgr.Instance.SetTimeText(Mathf.RoundToInt(timeLeft));
    }

    void SpawnItems()
    {
        GameObject ball = balls[Random.Range(0,balls.Length)];
        Quaternion rotation = Quaternion.identity;
        Vector3 position = new Vector3(
                            Random.Range(-ballRange, ballRange),
                            transform.position.y,
                            0.0f);
        Instantiate(ball, position, rotation);  
    }
}
