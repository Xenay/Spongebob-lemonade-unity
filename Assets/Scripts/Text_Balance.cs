using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Text_Balance : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI textField;
    
    // Start is called before the first frame update
    void Awake()
    {

        MainMenu mainMenu = new MainMenu();
        textField.text = $"You have {mainMenu.getBalance()} $ and";


    }

    // Update is called once per frame
    void Update()
    {
        MainMenu mainMenu = new MainMenu();
        textField.text = $"You have {mainMenu.getBalance()} $ and";
        
       
    }
   
}
