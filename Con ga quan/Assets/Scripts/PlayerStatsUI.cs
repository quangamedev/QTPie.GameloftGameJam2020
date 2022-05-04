using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    //public TextMeshProUGUI statDisplay;
    public TextMeshProUGUI moneyText;
    public Slider healthSlider;

    public void Start()
    {
        UpdatePlayerStatsUI();
    }

    public void UpdatePlayerStatsUI()
    {
        healthSlider.value = PlayerStats.Health / PlayerStats.MaxHealth;
        moneyText.text = PlayerStats.Money.ToString();
    }
}
