using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Adder : MonoBehaviour
{
    MainMenu mainMenu = new MainMenu();
    double price_per_cup = 0.25;
    float lemons_per_pitcher = 4;
    float sugar_per_pitcher = 4;
    float ice_per_cup = 5;
    public Button plus;
    public Button minus;
    public TextMeshProUGUI right_amount;

    private void Start()
    {
        
    }
    public void AddPrice()
    {
        price_per_cup += 0.05;
        right_amount.text = (price_per_cup).ToString();

    }
    public void AddLemons()
    {
        right_amount.text = (lemons_per_pitcher + 1).ToString();

    }
    public void AddSugar()
    {
        right_amount.text = (sugar_per_pitcher + 1).ToString();

    }
    public void AddIce()
    {
        right_amount.text = (ice_per_cup + 1).ToString();

    }

    public void DecreasePrice()
    {
        right_amount.text = (price_per_cup -= 0.05).ToString();
    }
    public void DecreaseLemons()
    {
        right_amount.text = (lemons_per_pitcher - 1).ToString();

    }
    public void DecreaseSugar()
    {
        right_amount.text = (sugar_per_pitcher - 1).ToString();

    }
    public void DecreaseIce()
    {
        right_amount.text = (ice_per_cup - 1).ToString();

    }
    public double getPrice()
    {
        return price_per_cup;
    }
    public double getIce()
    {
        return ice_per_cup;
    }

    public double getLemons()
    {
        return lemons_per_pitcher;
    }
    public double getSugar()
    {
        return sugar_per_pitcher;
    }
}
