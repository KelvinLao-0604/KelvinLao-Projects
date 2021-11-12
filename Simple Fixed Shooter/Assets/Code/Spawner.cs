using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnInterval = 2f;
    public int MaxWave = 10;
    public int NumberinWave = 10;
    public bool won = false;
    private bool LastRightSpawn = false;
    private int CountInWave;
    private int WaveNumber;
    public float NextSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        NextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextSpawn)
        {
            // spilt the spawns between left and right
            if (LastRightSpawn == true)
            {
                GameObject enemy = Instantiate(EnemyPrefab, new Vector3(-17f, -4.5f, 0), Quaternion.identity);
                LastRightSpawn = false;
            }
            else
            {
                GameObject enemy = Instantiate(EnemyPrefab, new Vector3(17f,-4.5f,0), Quaternion.identity);
                LastRightSpawn = true;
            }
            NextSpawn += SpawnInterval;
        }
        if (won == true)
        {
            Spawner.Destroy(gameObject);
        }
    }
}
