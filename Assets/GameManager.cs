using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
public class GameManager : MonoBehaviour
{
    private int playerScore;
    private int playerHighScore;

    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        enemySpawner.Activate();
    }
}
