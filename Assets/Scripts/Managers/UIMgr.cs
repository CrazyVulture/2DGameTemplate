using UnityEngine;
using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    public Text scoreText;

    void Start()
    {
        UIInit();
    }

    //UI Init
    void UIInit()
    {

    }

    public void SetCountText(int score)
    {
        scoreText.text = "Score:" + score.ToString();
    }

    public void SetWinText()
    {
        EventMgr.Instance.Win();
    }

    public float GetScreenWidthRange(Transform targetObj)
    {
        Vector3 border = new Vector3(Screen.width, Screen.height, 0.0f);
        float objWidth = targetObj.GetComponent<SpriteRenderer>().bounds.extents.x;
        float screenWidth = Camera.main.ScreenToWorldPoint(border).x - objWidth;
        return screenWidth;
    }

}
