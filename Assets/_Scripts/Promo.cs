using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class PromoData
{
    public string name;
    public int money;
    public int gems;
    public bool infinity;
    public PromoData(string name, int money, int gems, bool infinity)
    {
        this.name = name;
        this.money = money;
        this.gems = gems;
        this.infinity = infinity;
    }
}
public class Promo : MonoBehaviour
{
    public Text promoInput;
    public InputField inputField;
    public List<PromoData> promos;
    public List<string> activateds;
    public void AcceptPromo()
    {
        foreach (var promo in promos)
        {
            if (promo.name == promoInput.text)
            {
                foreach (var activated in activateds)
                {
                    if (activated == promo.name && !promo.infinity)
                    {
                        inputField.text = "Промокод уже активирован";
                        return;
                    }
                }
                Init.balance += Convert.ToInt32(promo.money);
                Init.gems += Convert.ToInt32(promo.gems);
                inputField.text = "АКТИВИРОВАНО!";
                activateds.Add(promo.name);
                return;
            }
        }
        inputField.text = "Промокод не найден";
    }
}
