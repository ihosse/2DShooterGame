using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private HUD hud;

    [SerializeField]
    private string gameSceneName;

    private void Start()
    {
        hud.UpdateScore(Globals.PlayerScore);
        hud.UpdateHiScore(Globals.PlayerHighScore);
    }

    private void Update()
    {
        if (inputHandler.GetFire1Button())
        {
           SceneManager.LoadScene(gameSceneName);
        }
    }
}
