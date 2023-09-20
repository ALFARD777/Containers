using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFifthTrigger : MonoBehaviour
{
    public GameObject openFifthButton;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            openFifthButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            openFifthButton.SetActive(false);
        }
    }
}
