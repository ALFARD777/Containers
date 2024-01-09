using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDrive : MonoBehaviour
{
    public void GoLaptop()
    {
        SceneManager.LoadScene("LaptopMenu");
    }
}
