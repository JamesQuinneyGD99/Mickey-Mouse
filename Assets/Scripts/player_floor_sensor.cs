using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_floor_sensor : MonoBehaviour
{
    public player playerScript;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag != "Player" && !collider.isTrigger){
            playerScript.jumps = 2;
        }
    }
}
