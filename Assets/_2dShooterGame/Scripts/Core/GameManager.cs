using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemySpawner))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private HUD hud;

    [SerializeField]
    private string menuSceneName;

    private EnemySpawner enemySpawner;
    private PlayerInfo playerInfo;
    private void Start()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();

        playerInfo.Score = 0;

        hud.UpdateScore(playerInfo.Score);
        hud.UpdateHiScore(playerInfo.HighScore);

        playerController.OnKilled += OnPlayerKilled;

        enemySpawner = GetComponent<EnemySpawner>();
        enemySpawner.Activate();
    }

    public void OnEnemyKilled(int points)
    {
        playerInfo.Score += points;
        hud.UpdateScore(playerInfo.Score);

        if (playerInfo.Score > playerInfo.HighScore)
        {
            playerInfo.HighScore = playerInfo.Score;
            hud.UpdateHiScore(playerInfo.HighScore);
        }
    }
    private void OnPlayerKilled()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(menuSceneName);
    }
}
