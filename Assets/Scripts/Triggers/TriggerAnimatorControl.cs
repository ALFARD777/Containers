using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimatorControl : MonoBehaviour
{
    public string nameTrigger;
    public GameObject _object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            _object.GetComponent<Animator>().SetTrigger(nameTrigger);
        }
    }
}
