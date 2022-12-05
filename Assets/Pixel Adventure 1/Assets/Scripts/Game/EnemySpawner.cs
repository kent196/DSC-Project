using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float maxSpawnRange = 1f;
    private float minSpawnRange = 30f;
    private int waveNumber = 1;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        Spawn(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("RespawnEnemy", 7f);
    }

    private void RespawnEnemy()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Spawn(waveNumber);
        }
    }
    private void Spawn(int enemy)
    {

        for (int i = 0; i < enemy; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPos(), enemyPrefabs.transform.rotation);

        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(minSpawnRange, maxSpawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, 0);
        return spawnPos;
    }
}
