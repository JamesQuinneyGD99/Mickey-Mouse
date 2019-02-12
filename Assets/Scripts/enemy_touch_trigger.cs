using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_touch_trigger : MonoBehaviour
{
    public enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "floor sensor"){
            enemyScript.touchingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "floor sensor")
        {
            enemyScript.touchingPlayer = false;
        }
    }
}
