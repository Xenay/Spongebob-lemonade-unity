using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdderUpdater : MonoBehaviour
{
    Adder adder = new Adder();
    public TextMeshProUGUI ppc;
    public TextMeshProUGUI lemons;
    public TextMeshProUGUI sugar;
    public TextMeshProUGUI ice;
    // Update is called once per frame
    void Update()
    {
        ppc.text = adder.getPrice().ToString();
        lemons.text = adder.getLemons().ToString();
        sugar.text = adder.getSugar().ToString();
        ice.text = adder.getIce().ToString();
    }
}
