using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFirstTrigger : MonoBehaviour
{
    public GameObject openFirstButton;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            openFirstButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            openFirstButton.SetActive(false);
        }
    }
}
