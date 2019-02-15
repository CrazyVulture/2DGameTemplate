using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] balls;

    float ballRange;

    public float timeLeft;

    public bool isStart { get; private set; }

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
            if (timeLeft < 0)
                timeLeft = 0;
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
        if (UIMgr.Instance.score > 0)
            EventMgr.Instance.WinGame();
        else
            EventMgr.Instance.LoseGame();
    }

    void UpdateText()
    {
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
