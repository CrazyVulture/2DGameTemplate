
using UnityEngine;

public class RogueGameController : GameController
{
    public RoguePlayerController playerController;

    StageSpawner stageSpawner;

    int level = 3;

    void Awake()
    {
        stageSpawner = GetComponent<StageSpawner>();
        StartGame();
    }

    public override void StartGame()
    {
        base.StartGame();
        stageSpawner.SetupScene(level);
        playerController.ToggleControl(true);
    }
}
