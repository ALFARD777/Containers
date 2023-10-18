using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class RunOpen : MonoBehaviour
{
    public Init Init;
    public GameObject notEnoughMoneyMenu;
    public GameObject timerGroup;
    public Text timerText;
    public RandomSpawn RandomSpawn;
    public GameObject colliders;
    public Sell Sell;
    [HideInInspector] public int containerIntCost;
    [HideInInspector] public int containerToOpen;
    [HideInInspector] public static List<List<GameObject>> contList;
    public void RunOpenContainer()
    {
        contList = new List<List<GameObject>>
        {
            Init.firstContainersList,
            Init.secondContainersList,
            Init.thirdContainersList,
            Init.fourthContainersList,
            Init.fifthContainersList
        };
        if (Init.CheckBalance(containerIntCost))
        {
            Init.balance -= containerIntCost;
        }
        else
        {
            notEnoughMoneyMenu.SetActive(true);
            return;
        }
        StartCoroutine(TimerAndOpen(contList));
    }
    private IEnumerator TimerAndOpen(List<List<GameObject>> contList)
    {
        foreach (var cont in contList)
        {
            cont[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        timerGroup.SetActive(true);
        colliders.SetActive(true);
        RandomSpawn.SpawnCars();
        for (int i = 5; i > 0; i--)
        {
            timerText.text = "00:0" + i;
            yield return new WaitForSeconds(1f);
        }
        timerGroup.SetActive(false);
        timerText.text = "00:05";
        for (int i = 0; i < contList[containerToOpen].Count; i++)
        {
            if (contList[containerToOpen][i].activeSelf)
            {
                GameObject doors = contList[containerToOpen][i].transform.Find("Doors").gameObject;
                doors.GetComponent<Animator>().enabled = true;
                doors.GetComponent<Animator>().SetTrigger("Open");
                break;
            }
        }
        Sell.StartSell();
    }
}
