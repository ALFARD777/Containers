using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Parking : MonoBehaviour
{
    public static List<string> playerCarsStrings;
    public List<GameObject> playerCarsList;
    public List<Transform> spawnPoints;
    public Text balanceText;
    [HideInInspector] private float timerInterval = 120f;
    [HideInInspector] public static bool visited = false;
    private void Start()
    {
        if (!visited)
        {
            visited = true;
            playerCarsStrings = new List<string>();
            playerCarsList = new List<GameObject>();
            spawnPoints = new List<Transform>();
        }
        playerCarsStrings.Add("Lambargabar");
        balanceText.text = Init.balance.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".") + "$";
        InvokeRepeating("AddTimeBalance", timerInterval, timerInterval);
        foreach (string carString in playerCarsStrings)
        {
            string path = @"Assets/_Cars/" + DeterminePrefabFolder(carString) + "/" + carString + ".prefab";
            GameObject prefab = Resources.Load<GameObject>(path);
            if (prefab != null)
            {
                playerCarsList.Add(prefab);
            }
            else
            {
                Debug.LogError("Префаб не найден: " + path);
            }
        }
        for (int i = 0; i < playerCarsList.Count; i++)
        {
            GameObject car = Instantiate(playerCarsList[i], spawnPoints[i].transform.position, Quaternion.identity);
            car.transform.Rotate(0, 90, 0);
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
    private string DeterminePrefabFolder(string name)
    {
        string[] countries = { "American", "Dubai", "Japan", "European", "Soviet" };
        foreach (string country in countries)
        {
            if (File.Exists(Application.dataPath + "/_Cars/" + country + "/" + name + ".prefab"))
            {
                return country;
            }
        }
        return null;
    }
    public override string ToString()
    {
        string res = "";
        foreach (var item in playerCarsStrings)
        {
            res += item.ToString() + "\n";
        }
        return res;
    }
}
