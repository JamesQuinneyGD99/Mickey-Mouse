using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point_add : MonoBehaviour
{
    public int amount;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Canvas").gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-40.0f,40.0f),Random.Range(50.0f,55.0f)));
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-spawnTime>1.0f){
            player.points += amount;
            GameObject.Find("Player Points").GetComponent<Text>().text = ""+player.points;
            spawnTime = 9999999.0f;
            Destroy(gameObject);
        }
    }

    public static void AddPoints(int toAdd,Vector2 pos,GameObject pointAdd){
        GameObject pointObject = Instantiate(pointAdd,pos,Quaternion.identity);
        pointObject.GetComponent<point_add>().amount = toAdd;
        pointObject.transform.Find("Canvas/Text").gameObject.GetComponent<Text>().text = ""+toAdd;
    }
}
