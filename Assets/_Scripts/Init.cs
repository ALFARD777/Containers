using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Init : MonoBehaviour
{
    [HideInInspector] public int containerToOpen;
    [HideInInspector] public static bool isBalanceWasSet = false;
    public static long balance = 0;
    public static long gems = 0;
    public Text balanceText;
    public Text gemsText;
    public List<GameObject> firstContainersList;
    public List<GameObject> secondContainersList;
    public List<GameObject> thirdContainersList;
    public List<GameObject> fourthContainersList;
    public List<GameObject> fifthContainersList;
    public int firstContainerNumber;
    [HideInInspector] public int secondContainerNumber;
    [HideInInspector] public int thirdContainerNumber;
    [HideInInspector] public int fourthContainerNumber;
    [HideInInspector] public int fifthContainerNumber;
    [HideInInspector] private float timerInterval = 120.0f;
    void Start()
    {
        if (!isBalanceWasSet)
        {
            balance = 200000000;
            isBalanceWasSet = true;
        }
        InvokeRepeating("AddTimeBalance", timerInterval, timerInterval);
        RandomFirst();
        RandomSecond();
        RandomThird();
        RandomFourth();
        RandomFifth();
    }
    void Update()
    {
        balanceText.text = balance.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".") + "$";
        gemsText.text = gems.ToString();
    }
    public void AddBalance(int count)
    {
        balance += count;
    }
    public void RemoveBalance(int count)
    {
        balance -= count;
    }
    public bool CheckBalance(int count)
    {
        return count <= balance;
    }
    public void AddGems(int count)
    {
        gems += count;
    }
    public void RemoveGems(int count)
    {
        gems -= count;
    }
    public bool CheckGems(int count)
    {
        return count <= gems;
    }
    private void AddTimeBalance()
    {
        balance += 200000;
    }
    public void RandomFirst()
    {
        foreach (GameObject firstContainer in firstContainersList)
        {
            firstContainer.SetActive(false);
        }
        firstContainerNumber = Random.Range(0, firstContainersList.Count);
        firstContainersList[firstContainerNumber].SetActive(true);
        firstContainersList[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void RandomSecond()
    {
        foreach (GameObject secondContainer in secondContainersList)
        {
            secondContainer.SetActive(false);
        }
        secondContainerNumber = Random.Range(0, secondContainersList.Count);
        secondContainersList[secondContainerNumber].SetActive(true);
        secondContainersList[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void RandomThird()
    {
        foreach (GameObject thirdContainer in thirdContainersList)
        {
            thirdContainer.SetActive(false);
        }
        thirdContainerNumber = Random.Range(0, thirdContainersList.Count);
        thirdContainersList[thirdContainerNumber].SetActive(true);
        thirdContainersList[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void RandomFourth()
    {
        foreach (GameObject fourthContainer in fourthContainersList)
        {
            fourthContainer.SetActive(false);
        }
        fourthContainerNumber = Random.Range(0, fourthContainersList.Count);
        fourthContainersList[fourthContainerNumber].SetActive(true);
        fourthContainersList[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    public void RandomFifth()
    {
        foreach (GameObject fifthContainer in fifthContainersList)
        {
            fifthContainer.SetActive(false);
        }
        fifthContainerNumber = Random.Range(0, fifthContainersList.Count);
        fifthContainersList[fifthContainerNumber].SetActive(true);
        fifthContainersList[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
