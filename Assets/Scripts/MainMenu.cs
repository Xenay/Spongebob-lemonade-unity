using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    static double balance = 20;
    static int paper_cups;
    double lemons_price = 0.50;
    static int lemons;
    double paper_cup_price = 0.90;
    static int cups_sugar;
    double ice_cubes_price = 0.60;
    static int ice_cubes;
    double cups_sugar_price = 0.70;
    public TextMeshProUGUI amount;
    int counter = 0;


    private void Awake()
    {
        
        //random values
        lemons_price += System.Math.Round(Random.Range(0.0f, 0.2f),2);
        paper_cup_price +=  System.Math.Round(Random.Range(0.0f, 0.2f),2);
        ice_cubes_price +=  System.Math.Round(Random.Range(0.0f, 0.2f),2);
        cups_sugar_price +=  System.Math.Round(Random.Range(0.0f, 0.2f),2);
        
    }
    

    public void Increment()
    {
        if (balance > 0)
        {
            counter++;
            amount.text = counter.ToString();

            Debug.Log(amount);
            //irrelevant, just for debugging
        }   
    }
    public void Decrease_paper_cups()
    {
        if (balance >= paper_cup_price)
        {
            balance = balance - paper_cup_price;
            paper_cups += 50;
            amount.text = paper_cups.ToString();
            Debug.Log(balance);
        }
    }

    public void Decrease_lemons()
    {
        if (balance >= lemons_price)
        {
            balance = balance - lemons_price;
            lemons += 30;
            amount.text = lemons.ToString();
            Debug.Log(lemons);
        }
    }

    public void Decrease_cups_sugar()
    {
        if (balance >= cups_sugar_price)
        {
            balance = balance - cups_sugar_price;
            cups_sugar += 20;
            amount.text = cups_sugar.ToString();
            Debug.Log(cups_sugar);
        }

    }

    public void Decrease_ice_cubes()
    {
        if (balance >= ice_cubes_price)
        {
            balance = balance - ice_cubes_price;
            ice_cubes += 100;
            amount.text = ice_cubes.ToString();
            Debug.Log(balance);
        }
    }
    //getters setters
    public double getBalance()
    {
        return balance;
    }
    public void setBalance(double x)
    {
        balance = x;
    }
    public void setCups(int x)
    {
        paper_cups = x;
    }
    public void setLemons(int x)
    {
        lemons = x;
    }
    public void setSugar(int x)
    {
        cups_sugar = x;
    }
    public void setIce(int x)
    {
        ice_cubes = x;
    }
    public int getLemons()
    {
        return lemons;
    }
    public int getSugars()
    {
        return cups_sugar;
    }
    public int getCups()
    {
        return paper_cups;
    }


  

}
