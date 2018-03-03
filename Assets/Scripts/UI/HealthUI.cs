using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;

    // Use this for initialization
    void Awake()
    {
        healthText.text = Player.Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Player.Health.ToString();
    }
}
