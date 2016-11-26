using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    //Waves will spawn units in waves.
    //OneTimeSpawn will spawn a selected amount of units once.
    //SurviveForTime will continue to spawn units until time runs out.

    public enum Status { None, Waves, OneTimeSpawn, SurviveForTime };

    [Header("Object Adjustment Variables")]
    [HideInInspector]
    public Status state;

    
    public static int activeEnemies;

    [Tooltip("The enemy prefab.")]
    public GameObject[] enemies;

    [Tooltip("Where the enemies could spawn.")]
    public GameObject[] spawnPoints;

    //Wave Variables
    [HideInInspector, Tooltip("How many enemies should there be per wave?")]
    public int enemiesPerWave;
    [HideInInspector, Tooltip("This number gets added to the enemiesPerWave after every wave.")]
    public int increaseEnemiesInWaveBy;
    [HideInInspector, Tooltip("The total number of waves.")]
    public int totalWaves;
    [HideInInspector]
    public static bool startNextWave;
    int currentWave;
    bool canSpawn;
    bool hasSpawned;
    int lastTime;

    //One Time Spawn Variables
    [HideInInspector, Tooltip("How many enemies do you want to spawn?")]
    public int totalEnemies;

    //Survive Variables
    [HideInInspector, Tooltip("How much timer you want the player to survive for in seconds.")]
    public int surviveFor;
    [HideInInspector, Tooltip("This is when the next set of enemies will be spawned. If set to 10 for example, it will spawn new enemies every 10seconds.")]
    public int nextWaveAt;
    [HideInInspector, Tooltip("How many enemies you want to spawn at each wave spawn.")]
    public int enemiesPerEachWave;
    void Start()
    {
        startNextWave = true;
        canSpawn = true;
    }

    void Update()
    {
        switch(state)
        {
            case Status.None:
                print("No spawning state has been selected.");
                break;
            case Status.Waves:
                    Waves();
                print(startNextWave);
                break;
            case Status.OneTimeSpawn:
                if (canSpawn)
                    OneTimeSpawn();
                break;
            case Status.SurviveForTime:
                if((int)Time.time <= surviveFor)
                {
                    if ((int)Time.time % nextWaveAt == 0 && (int)Time.time != lastTime)
                    {
                        lastTime = (int)Time.time;
                        Survive();
                    }
                }
               break;
        }
    }

    void Waves()
    {
        if(currentWave < totalWaves && startNextWave)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject clone = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity) as GameObject;
                activeEnemies++;
            }
            currentWave++;
        }

        startNextWave = false;

    }

    void OneTimeSpawn()
    {
        for(int i = 0; i < totalEnemies; i++)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
        canSpawn = false;
    }

    void Survive()
    {
        for (int i = 0; i < enemiesPerEachWave; i++)
        {
            GameObject clone = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity) as GameObject;
        }
    }
}
//Still need to set up the vairables and the logic.