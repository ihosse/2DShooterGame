using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyFast;

    [SerializeField]
    private GameObject enemyShooter;

    [SerializeField]
    private GameObject enemyHeavy;

    [SerializeField]
    private Transform[] spawners;

    private IEnumerator spawnerCoroutine;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        foreach (Transform spawnPoint in spawners)
            Gizmos.DrawSphere(spawnPoint.position, .5f);
    }
    public void Activate() 
    {
        spawnerCoroutine = Spawner();
        StartCoroutine(spawnerCoroutine);
    }

    public void Deactivate()
    {
        StopCoroutine(spawnerCoroutine);
    }

    private IEnumerator Spawner() 
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            CreateEnemy(enemyFast, spawners[2].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFast, spawners[1].transform);
            CreateEnemy(enemyFast, spawners[3].transform);

            yield return new WaitForSeconds(.5f);

            CreateEnemy(enemyFast, spawners[0].transform);
            CreateEnemy(enemyFast, spawners[4].transform);

            yield return new WaitForSeconds(2f);

            CreateEnemy(enemyFast, spawners[1].transform);
            CreateEnemy(enemyFast, spawners[3].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyFast, spawners[0].transform);
            CreateEnemy(enemyFast, spawners[2].transform);
            CreateEnemy(enemyFast, spawners[4].transform);

            yield return new WaitForSeconds(2);

            CreateEnemy(enemyShooter, spawners[2].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyShooter, spawners[1].transform);
            CreateEnemy(enemyShooter, spawners[3].transform);

            yield return new WaitForSeconds(1);

            CreateEnemy(enemyFast, spawners[0].transform);
            CreateEnemy(enemyFast, spawners[2].transform);
            CreateEnemy(enemyFast, spawners[4].transform);

            yield return new WaitForSeconds(3);

            CreateEnemy(enemyHeavy, spawners[1].transform);

            yield return new WaitForSeconds(10);
        }
    }

    private void CreateEnemy(GameObject selectedEnemy, Transform transform) 
    {
        GameObject enemy = Instantiate(selectedEnemy);
        enemy.transform.position = transform.position;
    }
}
