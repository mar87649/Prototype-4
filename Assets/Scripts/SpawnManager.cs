using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange = 8;
    public int enemyCount;
    public int waveCount;
    void Start()    
    {      
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount =  FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0){
            waveCount++;
            SpawnEnemyWave(waveCount);
            Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);

        }
    }

    private Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);  
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);  

        Vector3 randomPosition = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPosition;
    } 

    private void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
