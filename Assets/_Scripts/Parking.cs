using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Parking : MonoBehaviour
{
    [HideInInspector] public static List<GameObject> playerCarsList;
    public List<Transform> spawnPoints;
    public Text balanceText;
    [HideInInspector] private float timerInterval = 120f;
    [HideInInspector] public static bool visited = false;
    public void AddCar(GameObject car)
    {
        playerCarsList.Add(car);
    }
    public void RemoveCar(GameObject car)
    {
        playerCarsList.Remove(car);
    }
    private void Start()
    {
        if (!visited)
        {
            visited = true;
            playerCarsList = new List<GameObject>();
            spawnPoints = new List<Transform>();
        }
        balanceText.text = Init.balance.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".") + "$";
        InvokeRepeating("AddTimeBalance", timerInterval, timerInterval);
        for (int i = 0; i < playerCarsList.Count; i++)
        {
            GameObject car = Instantiate(playerCarsList[i], spawnPoints[i].transform.position, Quaternion.identity);
            car.AddComponent(typeof(Rigidbody));
        }
    }
    private void AddTimeBalance()
    {
        Init.balance += 200000;
    }
    private void Update()
    {
        balanceText.text = Init.balance.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".") + "$";
    }
}
