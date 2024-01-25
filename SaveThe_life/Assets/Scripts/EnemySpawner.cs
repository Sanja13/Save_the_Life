using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float xPositionLimit;

    [SerializeField] private float spawnRate;



    private void Start()
    {
        //SpawnSpike();
        StartSpawning();
    }
    private void SpawnSpike()
    {
        float randomX = Random.Range(-xPositionLimit, xPositionLimit);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);
        Instantiate(enemy, spawnPosition , Quaternion.identity);
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnSpike", 1f, spawnRate);
    }
    public void StopSpawing()
    {
        CancelInvoke("SpawnSpike");
        GameObject.Find("EnemySpawn");
    } 
}
