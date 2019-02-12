using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LineRenderer>().positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount>0){
            GetComponent<LineRenderer>().SetPosition(0,transform.position);
            GetComponent<LineRenderer>().SetPosition(1,new Vector3(transform.GetChild(0).position.x,transform.GetChild(0).position.y,-0.1f));
        }
        else{
            GetComponent<LineRenderer>().positionCount = 0;
        }
    }
}
