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
    public GameObject enterHighway;
    public Text enterHighwayText;
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
    public void GarageCost()
    {
        if (openedLocations.Contains("Garage")) buyGarage.SetActive(true);
        else buyGarage.SetActive(true);
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
    public void CheckAuto()
    {
        try
        {
            if (!Parking.playerCarsStrings.Contains("Lambargabar")) throw new Exception();
            enterHighway.SetActive(true);
            enterHighwayText.text = "Выбрано";
        }
        catch (Exception)
        {
            enterHighway.SetActive(false);
            enterHighwayText.text = "Требуется Ламба";
        }
    }
}
