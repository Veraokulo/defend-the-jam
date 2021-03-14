using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float delay = 1f;
    public float delayMultiplier = 0.98f;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(EnemyPrefab, Random.insideUnitCircle.normalized * 10, Quaternion.identity);
            yield return new WaitForSeconds(delay);
            delay *= delayMultiplier;
        }
    }
}
