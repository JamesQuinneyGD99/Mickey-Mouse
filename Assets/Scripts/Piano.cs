using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    bool touchingPlayer;
    public static float nextFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touchingPlayer && Input.GetKeyDown("e")){
            nextFollow = Time.time + 2;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            touchingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
            touchingPlayer = false;
        }
    }
}
