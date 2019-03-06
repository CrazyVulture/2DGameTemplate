
public class CollectGameController : GameController
{
    public CharaPlayerController charaController;

    public override void StartGame()
    {
        base.StartGame();
        UIMgr.Instance.StartGameUI();
        charaController.ToggleControl(true);
    }

    public override void EndGame(bool isWin)
    {
        charaController.ToggleControl(false);
        charaController.StayInPos();
        base.EndGame(isWin);
    }
}
