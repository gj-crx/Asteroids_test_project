using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemiesSpawner
{
    /// <summary>
    /// enemie types that being spawned
    /// </summary>
    public static List<EnemyType> EnemieTypes;
    public static void InitializeEnemies(GameObject[] prefabs)
    {
        EnemieTypes = new List<EnemyType>();
        foreach (GameObject v in prefabs)
        {
            if (v != null)
            {
                EnemieTypes.Add(v.GetComponent<EnemyType>());
            }
        }
    }
    public static void SpawnEnemy(GameObject EnemyPrefab)
    {
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, GameLogic.GetRandomBorderPosition(), Quaternion.identity);
    }
    public static void DestroyBigAsteroid(GameObject asteroid)
    { //asteroid collapses to many particles
        int ParticlesCount = Random.Range(1, 5);
        for (int i = 0; i < ParticlesCount; i++)
        {
           GameObject.Instantiate(GameLogic.gc.Prefab_AsteroidParticle, asteroid.transform.position, Quaternion.identity);
        }
        GameObject.Destroy(asteroid);
    }
    
}

