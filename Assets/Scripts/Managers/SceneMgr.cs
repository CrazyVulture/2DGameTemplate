using UnityEngine;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public AudioClip bgmMusic;
    public AudioClip winSound;

    public static SceneMgr Instance=null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
            Instance = this;
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        if (Instance != this)
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        winText.text = "";
        SoundMgr.Instance.PlayMusic(bgmMusic,true);
    }

    public void SetCountText(int count)
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 12)
        {
            winText.text = "You win!";
            SoundMgr.Instance.PlayMusic(winSound);
        }
            
    }
}
