
public class CollectGameController : GameController
{
    public CharaPlayerController charaController;

    public override void StartGame()
    {
        base.StartGame();
        charaController.ToggleControl(true);
    }

    public override void EndGame(bool isWin)
    {
        charaController.ToggleControl(false);
        charaController.StayInPos();
        base.EndGame(isWin);
    }
}
