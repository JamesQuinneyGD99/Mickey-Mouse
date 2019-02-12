using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_spawner : MonoBehaviour
{
    float nextSpawn;
    public int toSpawn;
    public float spawnDelay;
    int spawned;
    public GameObject batObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player==null || Vector3.Distance(player.transform.position,transform.position) < 5.0f){
            if(Time.time > nextSpawn){
                nextSpawn = Time.time + spawnDelay;
                spawned+=1;

                GameObject bat = Instantiate(batObject,transform.position,Quaternion.identity);
                bat.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-8.0f,8.0f),Random.Range(-8.0f,8.0f));
            }
            if (toSpawn <= spawned)
            {
                Destroy(gameObject);
            }
        }
    }
}
