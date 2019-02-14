
public class CatcherGameController : GameController
{

    public BallController ballController;

    public HatPlayerController hatController;

    public override void StartGame()
    {
        base.StartGame();
        hatController.ToggleControl(true);
        StartCoroutine(ballController.Spawn());
    }

    public override void EndGame(bool isWin)
    {
        hatController.ToggleControl(false);
        base.EndGame(isWin);
    }
}
