using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTimer : MonoBehaviour
{
    public Text Text;
    [HideInInspector] private int min = 2;
    [HideInInspector] private int sec = 0;
    void Start()
    {
        InvokeRepeating("UpdateTime", 0.0f, 1.0f);
    }
    void UpdateTime()
    {
        if (min == 0 && sec == 0) min = 2;
        if (sec == 0)
        {
            min--;
            sec = 59;
        }
        else sec--;
        Text.text = $"0{min}:";
        if (sec < 10) Text.text += $"0{sec}";
        else Text.text += sec;
    }
}
