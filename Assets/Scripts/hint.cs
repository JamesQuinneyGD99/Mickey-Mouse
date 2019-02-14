using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint : MonoBehaviour
{
    public static float resetHint = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(resetHint<Time.time){
            Text hintText = GameObject.Find("Hint Text").GetComponent<Text>();
            hintText.text = "Hint: ";
        }
    }

    public static void SetHint(string setHint, float amount){
        resetHint = Time.time + amount;
        Text hintText = GameObject.Find("Hint Text").GetComponent<Text>();
        hintText.text = "Hint: "+setHint;
    }
}
