using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Updater : MonoBehaviour
{
    Adder adder = new Adder();
    Logic logic = new Logic();
    MainMenu main = new MainMenu();
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    
    public TextMeshProUGUI day;
    
    public void Update()
    {
        
        score1.text = main.getCups().ToString();
        score2.text = main.getLemons().ToString();
        score3.text = main.getSugars().ToString();
        day.text = logic.getCurrentDay().ToString();
        


    }
    // Start is called before the first frame update
   

}
