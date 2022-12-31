using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wolfPrefab, wolfEaterPrefab;
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private int eaterChance = 3;
    [SerializeField]
    private float initSpawnTime = 12f;
    [SerializeField]
    private float spawnTimeReduction = 0.75f;
    [SerializeField]
    private float minSpawnTime = 3f;
    private float currentSpawnTime;
    private float timer;
    void Start()
    {
        currentSpawnTime = initSpawnTime;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer){
            Spawn();
            currentSpawnTime -= spawnTimeReduction;
            if(currentSpawnTime <= minSpawnTime)
                currentSpawnTime = minSpawnTime;
            timer = Time.time + currentSpawnTime;
        }
    }
    void Spawn(){
        if(Random.Range(0,10)>eaterChance){
            Instantiate(wolfPrefab,spawnPoints[Random.Range(0,spawnPoints.Length)].position,
            Quaternion.identity);
        }
        else{
            Instantiate(wolfEaterPrefab,spawnPoints[Random.Range(0,spawnPoints.Length)].position,
            Quaternion.identity);
        }
    }
    public void DestroyWolfSpawner(bool gameover){
        Destroy(gameObject);
    }
}
