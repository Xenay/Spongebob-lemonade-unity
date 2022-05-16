using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chatbubble : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lemonadeStand;
    public GameObject npc;
    public GameObject text;
    private float chance;
    private float distance;
    private void Start()
    {
        
        
        text.SetActive(false);
        chance = Random.Range(0, 10);
    }
    private void Update()
    {
        distance = Vector3.Distance(npc.transform.position, lemonadeStand.transform.position);
        
       
      
        
        if (distance < 1.6 && chance >= 5) 
        {
            text.SetActive(true);
        }
        else text.SetActive(false);

    }
   
}


