using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenThirdTrigger : MonoBehaviour
{
    public GameObject openThirdButton;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            openThirdButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            openThirdButton.SetActive(false);
        }
    }
}
