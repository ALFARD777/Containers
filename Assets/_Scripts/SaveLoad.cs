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
        }
        else
            Debug.Log("Сохраненная игровая информация не найдена");
    }
}
