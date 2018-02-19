using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Health;
    public int startHealth = 20;
    public static int Money;
    public int startMoney = 100;
    public static int Round;

    // Use this for initialization
    void Start()
    {
        Health = startHealth;
        Money = startMoney;
        Round = 0;
    }
}
