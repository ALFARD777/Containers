using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContainerPass : MonoBehaviour
{
    public Text rewardText;
    public Image rewardImage;
    public GameObject rewardButton;
    public Text quest1;
    public Text quest2;
    public Text quest3;
    public Text progress1;
    public Text progress2;
    public Text progress3;
    public Slider bar1;
    public Slider bar2;
    public Slider bar3;
    public Text playerLevel;
    public Text playerNextLevel;
    public Slider xpBar;
    public static int playerLevelNumber = 0;
    public static List<int> takenRewards = new List<int>();
    public void OpenPass()
    {
        SceneManager.LoadScene("ContainerPass");
    }
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "ContainerPass")
        {
            SetValues();
            UpdateProgress(quest1.text, bar1, progress1);
            UpdateProgress(quest2.text, bar2, progress2);
            UpdateProgress(quest3.text, bar3, progress3);
            if (bar1.value >= bar1.maxValue && bar2.value >= bar2.maxValue && bar3.value >= bar3.maxValue)
                UpgradeLevel();
        }
    }
    private void UpdateProgress(string quest, Slider bar, Text progress)
    {
        quest = quest.Remove(quest.Length - 1);
        switch (quest)
        {
            case "Собрать 20 наград за время":
                bar.value = Init.playTime;
                progress.text = Init.playTime + " / 20";
                break;
            case "Собрать 4.000.000$":
                bar.value = Init.balance;
                progress.text = Init.balance + " / 4000000";
                break;
            case "Выбить мусор из конт.":
                bar.value = Init.trashes;
                progress.text = Init.trashes + " / 1";
                break;
            case "Открыть 20 контейнеров":
                bar.value = Init.containerOpened;
                progress.text = Init.containerOpened + " / 20";
                break;
            case "Открыть гараж":
                bar.value = Parking.visited ? 1 : 0;
                progress.text = Parking.visited ? "1" : "0" + " / 1";
                break;
        }
        playerLevel.text = "LVL" + playerLevelNumber;
        playerNextLevel.text = "LVL" + (playerLevelNumber + 1);
        xpBar.value = FinishedQuests() * 250;
    }
    private void UpgradeLevel()
    {
        playerLevelNumber++;
        TextAsset textResource = Resources.Load<TextAsset>("Quests");
        if (textResource != null)
        {
            List<string> lines = textResource.text.Split('\n').ToList<string>();
            lines.RemoveRange(0, Mathf.Min(3, lines.Count));
            string newText = string.Join("\n", lines);
            TextAsset newTextAsset = new TextAsset(newText);
            File.WriteAllBytes("Assets/Resources/Quest_Modified.asset", newTextAsset.bytes);
            ResetValues();
        }
    }
    private void ResetValues()
    {
        Init.playTime = 0;
        Init.trashes = 0;
        Init.containerOpened = 0;
    }
    private void SetValues()
    {
        TextAsset textAsset;
        if (Resources.Load<TextAsset>("Quest_Modified.asset") != null)
            textAsset = Resources.Load<TextAsset>("Quest_Modified.asset");
        else textAsset = Resources.Load<TextAsset>("Quests");
        if (textAsset != null)
        {
            string[] quests = textAsset.text.Split('\n');
            quest1.text = quests[0];
            progress1.text = ProgressText(quests[0]);
            bar1.maxValue = ReadMinMax(progress1.text).Item2;
            bar1.value = ReadMinMax(progress1.text).Item1;
            quest2.text = quests[1];
            progress2.text = ProgressText(quests[1]);
            bar2.maxValue = ReadMinMax(progress2.text).Item2;
            bar2.value = ReadMinMax(progress2.text).Item1;
            quest3.text = quests[2];
            progress3.text = ProgressText(quests[2]);
            bar3.maxValue = ReadMinMax(progress3.text).Item2;
            bar3.value = ReadMinMax(progress3.text).Item1;
            playerLevel.text = "LVL" + playerLevelNumber;
            playerNextLevel.text = "LVL" + (playerLevelNumber + 1);
            xpBar.value = FinishedQuests() * 250;
        }
    }
    private int FinishedQuests()
    {
        int res = 0;
        Slider[] bars = { bar1, bar2, bar3 };
        foreach (Slider s in bars) if (s.value >= s.maxValue) res++;
        return res;
    }
    private string ProgressText(string quest)
    {
        quest = quest.Remove(quest.Length - 1);
        switch (quest)
        {
            case "Играть 60 минут":
                return "0 / 3";
            case "Собрать 4.000.000$":
                return "0 / 4000000";
            case "Выбить мусор из конт.":
                return "0 / 1";
            case "Открыть 20 контейнеров":
                return "0 / 20";
            default: return "NOT FOUND";
        }
    }
    private (int, int) ReadMinMax(string progress)
    {
        string[] mm = progress.Split(" / ");
        return (Convert.ToInt32(mm[0]), Convert.ToInt32(mm[1]));
    }
    public void ClosePass()
    {
        SceneManager.LoadScene(1);
    }
    public void ShowItem(string rewardName)
    {
        rewardText.text = rewardName;
        Debug.Log(rewardName);
        Sprite image = null;
        switch (rewardName)
        {
            case "Кристалл x1":
            case "Кристалл x3":
                image = LoadSprite("Assets/_Images/gen-icon.png");
                break;
            case "Локация":
                image = LoadSprite("Assets/_Images/island.png");
                break;
        }
        rewardImage.sprite = image;
    }
    private Sprite LoadSprite(string imagePath)
    {
        Texture2D texture = LoadTextureFromFile(imagePath);
        if (texture != null)
        {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        }
        else
        {
            Debug.LogError("Не удалось загрузить текстуру из файла: " + imagePath);
            return null;
        }
    }
    private Texture2D LoadTextureFromFile(string path)
    {
        byte[] fileData = System.IO.File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        return texture;
    }
    public void ShowButton()
    {
        if (playerLevelNumber >= Convert.ToInt32(rewardText.text[1]) && !takenRewards.Contains(Convert.ToInt32(rewardText.text[1])))
            rewardButton.SetActive(true);
        else rewardButton.SetActive(false);

    }
    public void TakeReward()
    {
        switch (Convert.ToInt32(rewardText.text[1]))
        {
            case 1:
                takenRewards.Add(1);
                Init.gems++;
                break;
            case 2:
                takenRewards.Add(2);
                Init.gems += 3;
                break;
            case 3:
                takenRewards.Add(3);
                break;
        }
    }
}
