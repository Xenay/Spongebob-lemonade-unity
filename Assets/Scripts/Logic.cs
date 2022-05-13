using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    // Start is called before the first frame update
    MainMenu mainMenu = new MainMenu();
    Adder adder = new Adder();
    int days = 7;
    double pitcher_num;
    private int highPrice = 1;
    private int demand = 10;
    private int num_of_people = 50;
    private String[] weatherList;
    private int currentDay;
    int num_of_cups;

    public void CalculateCups()
    {
        double ice = adder.getIce();
        if (ice < 6 && ice > 1) num_of_cups = 12;
        if (ice > 6 && ice < 10) num_of_cups=20;
        if (ice > 10) num_of_cups = 25;
        
    }
    public void CalculatePitchers()
    {
        pitcher_num = Math.Min(Math.Floor(mainMenu.getLemons() / adder.getLemons()), Math.Floor(mainMenu.getSugars() / adder.getSugar()));
        mainMenu.setLemons(Convert.ToInt32(mainMenu.getLemons() -pitcher_num * adder.getLemons()));
        mainMenu.setSugar(Convert.ToInt32(mainMenu.getSugars() - pitcher_num * adder.getSugar()));
    }
    public void Calculate()
    {
        CalculateCups();
        
        CalculatePitchers();
        num_of_cups = Convert.ToInt32(pitcher_num) * num_of_cups;
        Debug.Log(num_of_cups);

        if (mainMenu.getCups() < num_of_cups)
        {
            num_of_cups = mainMenu.getCups();
            
        }

        if (num_of_cups< num_of_people)
        {
            num_of_people = num_of_cups;
        }
        Debug.Log(num_of_people);
        currentDay += 1;
        mainMenu.setBalance(mainMenu.getBalance() + Math.Floor(BaseSales()) / 100 * num_of_people * adder.getPrice());
        //reduce cups
        
        mainMenu.setCups(num_of_cups-num_of_people);

        SceneManager.LoadScene(1);
       

        //reduce lemons



        
        //za cijenu 0.35 dodje 6 dollara nazad

    }
    double SalesFactor()
    {
        if(adder.getPrice()<highPrice)
        {
            return (highPrice - adder.getPrice()) / highPrice * 0.8 * demand + demand;
        }
        return Math.Pow(highPrice, 2) * demand / Math.Pow(adder.getPrice(), 2);
    }
    public double BaseSales()
    {
       /* if (weatherList[currentDay] == "Sunny") return SalesFactor() + 0.50 * SalesFactor();
        if (weatherList[currentDay] == "Stormy") return SalesFactor() - 0.50 * SalesFactor();
        if (weatherList[currentDay] == "Hot") return SalesFactor() + SalesFactor();
        if (weatherList[currentDay] == "Normal") return SalesFactor();*/
        return SalesFactor();
    }

}
