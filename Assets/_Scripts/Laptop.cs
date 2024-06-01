using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Laptop : MonoBehaviour
{
    public static string currentScene = "Nature";
    public Text clockText;
    public static List<string> openedLocations = new List<string>();
    public GameObject buyGarage;
    public GameObject buyPort;
    public GameObject buyAirport;
    public GameObject enterHighway;
    public Text enterHighwayText;
    private void Start()
    {
        Costs();
    }
    public void StartScene()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }
    private void Update()
    {
        clockText.text = DateTime.Now.ToString("HH:mm\ndd.MM.yyyy");
    }
    public void ChangeCurrentScene(string name)
    {
        currentScene = name;
    }
    public void Costs()
    {
        if (openedLocations.Contains("Garage")) buyGarage.SetActive(false);
        else buyGarage.SetActive(true);
        if (openedLocations.Contains("Port")) buyPort.SetActive(false);
        else buyPort.SetActive(true);
        if (openedLocations.Contains("Airport")) buyAirport.SetActive(false);
        else buyAirport.SetActive(true);
    }
    public void BuyGarage()
    {
        if (Init.balance >= 20000000)
        {
            Init.balance -= 20000000;
            buyGarage.SetActive(false);
            openedLocations.Add("Garage");
        }
    }
    public void BuyPort()
    {
        if (Init.balance >= 4000000)
        {
            Init.balance -= 4000000;
            buyPort.SetActive(false);
            openedLocations.Add("Port");
        }
    }
    public void BuyAirport()
    {
        if (Init.balance >= 8000000)
        {
            Init.balance -= 8000000;
            buyAirport.SetActive(false);
            openedLocations.Add("Airport");
        }
    }
    public void CheckAuto()
    {
        try
        {
            if (!Parking.playerCarsStrings.Contains("Lambargabar")) throw new Exception();
            enterHighway.SetActive(true);
            enterHighwayText.text = "�������";
        }
        catch (Exception)
        {
            enterHighway.SetActive(false);
            enterHighwayText.text = "��������� �����";
        }
    }
}
