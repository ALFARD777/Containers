using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseLaptop : MonoBehaviour
{
    public GameObject button1;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            button1.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            button1.SetActive(false);
        }
    }

    public void UsingLaptop()
    {
        SceneManager.LoadScene(1);
    }
}
