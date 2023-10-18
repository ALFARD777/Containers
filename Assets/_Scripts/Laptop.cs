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
    public void StartScene()
    {
        SceneManager.LoadScene(currentScene);
    }
    private void Update()
    {
        clockText.text = DateTime.Now.ToString("HH:mm\ndd.MM.yyyy");
    }
    public void ChangeCurrentScene(string name)
    {
        currentScene = name;
    }
}
