using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Updater : MonoBehaviour
{
    MainMenu main = new MainMenu();
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    
    private void Update()
    {
        score1.text = main.getCups().ToString();
        score2.text = main.getLemons().ToString();
        score3.text = main.getSugars().ToString();
      
    }
    // Start is called before the first frame update
   

}
