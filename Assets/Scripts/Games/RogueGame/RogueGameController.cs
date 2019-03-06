

public class RogueGameController : GameController
{
    public RoguePlayerController playerController;

    public override void StartGame()
    {
        base.StartGame();
        playerController.ToggleControl(true);
    }
}
