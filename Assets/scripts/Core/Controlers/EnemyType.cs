using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public float SpawningInternal = 3;
    public float timer_Spawning = 0;
    public void SpawningProcess()
    {
        if (timer_Spawning > SpawningInternal)
        {
            timer_Spawning = 0;
            EnemiesSpawner.SpawnUnit(gameObject);
        }
        else
        {
            timer_Spawning = timer_Spawning + Time.deltaTime;
        }
    }
}
