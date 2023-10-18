using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [HideInInspector] public List<GameObject> cars;
    [HideInInspector] public GameObject droppedCar;
    public List<GameObject> sovietCars;
    public List<GameObject> americaCars;
    public List<GameObject> dubaiCars;
    public List<GameObject> japanCars;
    public List<GameObject> euroCars;
    public List<Transform> spawnPoints;
    public RunOpen RunOpen;
    void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        sovietCars = new List<GameObject>(sovietCars);
        americaCars = new List<GameObject>(americaCars);
        dubaiCars = new List<GameObject>(dubaiCars);
        japanCars = new List<GameObject>(japanCars);
        euroCars = new List<GameObject>(euroCars);
    }
    public void SpawnCars()
    {
        switch (RunOpen.containerIntCost / 1000000)
        {
            case 1:
                cars = sovietCars;
                break;
            case 3:
                cars = americaCars;
                break;
            case 12:
                cars = dubaiCars;
                break;
            case 7:
                cars = japanCars;
                break;
            case 5:
                cars = euroCars;
                break;
            default:
                Debug.LogError("Неверный switch. Открываем EURO");
                cars = euroCars;
                break;
        }
        int car = UnityEngine.Random.Range(0, cars.Count);
        droppedCar = Instantiate(cars[car], spawnPoints[RunOpen.containerToOpen].transform.position, Quaternion.identity);
        Destroy(droppedCar.GetComponent(typeof(Rigidbody)));
        Destroy(droppedCar.GetComponent(typeof(BoxCollider)));
        Destroy(droppedCar.GetComponent(typeof(MeshCollider)));
        Destroy(droppedCar.GetComponent(typeof(SphereCollider)));
        
    }
}
