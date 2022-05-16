using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndRestart : MonoBehaviour
{
    MainMenu main = new MainMenu();
    public string levelToLoad;
    // Start is called before the first frame update
    public void quit()
    {
        Application.Quit();
    }
public void restart()
    {
        main.setBalance(20);
        main.setCups(0);
        main.setIce(0);
        main.setLemons(0);
        main.setSugar(0);
        SceneManager.LoadScene(levelToLoad);
    }
}
