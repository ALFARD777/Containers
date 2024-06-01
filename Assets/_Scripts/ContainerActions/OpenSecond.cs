using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSecond : MonoBehaviour
{
    public Text containerName;
    public Text containerCost;
    public Init Init;
    public RunOpen RunOpen;
    public void OpenSecondButtonClick()
    {
        Debug.Log("SecondButtonClicked");
        switch (Init.secondContainerNumber)
        {
            case 0:
                containerName.text = "���������";
                containerCost.text = "1.000.000$";
                RunOpen.containerIntCost = 1000000;
                break;
            case 1:
                containerName.text = "������������";
                containerCost.text = "3.000.000$";
                RunOpen.containerIntCost = 3000000;
                break;
            case 2:
                containerName.text = "���������";
                containerCost.text = "12.000.000$";
                RunOpen.containerIntCost = 12000000;
                break;
            case 3:
                containerName.text = "��������";
                containerCost.text = "7.000.000$";
                RunOpen.containerIntCost = 7000000;
                break;
            case 4:
                containerName.text = "�����������";
                containerCost.text = "5.000.000$";
                RunOpen.containerIntCost = 5000000;
                break;
        }
        RunOpen.containerToOpen = 1;
    }
}
