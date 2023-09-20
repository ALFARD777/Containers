using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFourthTrigger : MonoBehaviour
{
    public GameObject openFourthButton;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            openFourthButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            openFourthButton.SetActive(false);
        }
    }
}
