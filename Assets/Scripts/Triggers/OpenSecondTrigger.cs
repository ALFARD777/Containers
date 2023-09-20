using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecondTrigger : MonoBehaviour
{
    public GameObject openSecondButton;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            openSecondButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            openSecondButton.SetActive(false);
        }
    }
}
