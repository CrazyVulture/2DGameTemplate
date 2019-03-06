
public class CatcherGameController : GameController
{

    public BallSpawner ballSpawner;

    public HatPlayerController hatController;

    public override void StartGame()
    {
        base.StartGame();
        UIMgr.Instance.StartGameUI();
        hatController.ToggleControl(true);
        StartCoroutine(ballSpawner.Spawn());
    }

    public override void EndGame(bool isWin)
    {
        hatController.ToggleControl(false);
        base.EndGame(isWin);
    }
}
