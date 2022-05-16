using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    Updater updater = new Updater();
    Logic logic = new Logic();
    // Start is called before the first frame update
    public string levelToLoad;
    public string otherLevelToLoad;
    private float timer = 10f;
    private static int day;
   

    void Start()
    {
        logic = new Logic();
        day = logic.getCurrentDay();
        Debug.Log(logic.getCurrentDay());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            if (day == 7)
            {
                SceneManager.LoadScene(otherLevelToLoad);

            }
            else
            SceneManager.LoadScene(levelToLoad);
            



        }
    }
}
