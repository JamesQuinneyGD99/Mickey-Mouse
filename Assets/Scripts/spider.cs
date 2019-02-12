using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    float nextJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>nextJump){
            nextJump=Time.time + Random.Range(1.0f,2.5f);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-125.5f,125.5f),Random.Range(-250.0f,250.0f)));
        }
    }
}
