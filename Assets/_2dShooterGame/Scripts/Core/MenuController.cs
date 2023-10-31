using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(InputHandler))]
public class MenuController : MonoBehaviour
{
    [SerializeField]
    private HUD hud;

    [SerializeField]
    private string gameSceneName;

    private InputHandler inputHandler;

    private PlayerInfo playerInfo;

    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();

        inputHandler = GetComponent<InputHandler>();

        hud.UpdateScore(playerInfo.Score);
        hud.UpdateHiScore(playerInfo.HighScore);
    }

    private void Update()
    {
        if (inputHandler.GetFire1Button())
        {
           SceneManager.LoadScene(gameSceneName);
        }
    }
}
