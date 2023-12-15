using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SaveData
{
    public long balance;
    public long gems;
    public bool parkingVisited;
    public bool startBalanceSet;
    public int playTime;
    public int trashes;
    public int containerOpened;
    public int playerLevelNumber;
    public List<int> takenRewards;
    public List<string> playerCarsStrings;
    public List<string> openedLocations;
}

public class SaveLoad : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        SaveData data = new SaveData();
        data.balance = Init.balance;
        data.gems = Init.gems;
        data.parkingVisited = Parking.visited;
        data.startBalanceSet = Init.isBalanceWasSet;
        data.playTime = Init.playTime;
        data.trashes = Init.trashes;
        data.containerOpened = Init.containerOpened;
        data.playerLevelNumber = ContainerPass.playerLevelNumber;
        data.takenRewards = ContainerPass.takenRewards;
        data.playerCarsStrings = Parking.playerCarsStrings;
        data.openedLocations = Laptop.openedLocations;
        bf.Serialize(file, data);
        file.Close();
    }
    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Init.balance = data.balance;
            Init.gems = data.gems;
            Parking.visited = data.parkingVisited;
            Init.isBalanceWasSet = data.startBalanceSet;
            Init.playTime = data.playTime;
            Init.trashes = data.trashes;
            Init.containerOpened = data.containerOpened;
            ContainerPass.playerLevelNumber = data.playerLevelNumber;
            ContainerPass.takenRewards = data.takenRewards;
            Parking.playerCarsStrings = data.playerCarsStrings;
            Laptop.openedLocations = data.openedLocations;
        }
        else
            Debug.Log("Сохраненная игровая информация не найдена");
    }
}
