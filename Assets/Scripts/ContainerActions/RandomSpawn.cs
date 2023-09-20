using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Gameo> cars;
    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnCars();
    }
    void SpawnCars()
    {
        var car = Random
        for (int i = 0; i < cars.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(cars[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
    }
}
