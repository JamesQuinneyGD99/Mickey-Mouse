using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerHint : MonoBehaviour
{
    public string hintText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            hint.SetHint(hintText,5.0f);
        }
    }
}
