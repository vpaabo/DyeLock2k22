using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyExampleAI> enemyPrefabs; // This should be replaced by a superclass in the future
    public float intervalMin;
    public float intervalMax;
    public GameObject player; // To set as movement target

    private float intervalCurrent;
    
    // Start is called before the first frame update
    void Start()
    {
        genInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if (intervalCurrent <= 0)
        {
            genInterval();
            spawnEnemy();
        } else
        {
            intervalCurrent -= Time.deltaTime;
        }
    }

    private void genInterval()
    {
        intervalCurrent = intervalMin + Random.value * (intervalMax - intervalMin);
    }

    private void spawnEnemy()
    {
        EnemyExampleAI enemy = GameObject.Instantiate<EnemyExampleAI>(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], transform.position, transform.rotation);
        enemy.movementTarget = player; // TODO: Change to fit generic AI whenever we get to it
    }
}
