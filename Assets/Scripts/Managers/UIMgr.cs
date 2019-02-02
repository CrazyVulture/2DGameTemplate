using UnityEngine.UI;

public class UIMgr : Singleton<UIMgr>
{
    public Text countText;
    public Text winText;

    void Start()
    {
        UIInit();
    }

    //UI Init
    void UIInit()
    {
        winText.text = "";
    }

    public void SetCountText(int score)
    {
        countText.text = "Score:" + score.ToString();
    }

    public void SetWinText()
    {
        winText.text = "You win!";
        EventMgr.Instance.Win();
    }

}
