using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowProfit : MonoBehaviour
{
    MainMenu mainMenu = new MainMenu();
    public TextMeshProUGUI text = new TextMeshProUGUI();
    // Start is called before the first frame update
    void Start()
    {
        text.text += (mainMenu.getBalance()-20).ToString();
        text.text += "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
