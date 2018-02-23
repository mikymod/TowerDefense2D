using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    // Use this for initialization
    void Awake()
    {
        moneyText.text = Player.Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = Player.Money.ToString();
    }
}
