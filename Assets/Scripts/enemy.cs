using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public bool touchingPlayer;
    public GameObject pointObject;
    public float damage;
    public int hits = 1;
    float nextDamage;
    float nextFlicker;
    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sprite.GetComponent<SpriteRenderer>()!=null){
            if(Time.time < nextDamage && Time.time > nextFlicker){
                nextFlicker = Time.time + 0.1f;
                sprite.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,Mathf.Abs(sprite.GetComponent<SpriteRenderer>().color.a-1.0f));
            }
            else{
                sprite.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,1.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            if(Time.time > nextDamage){
                if(touchingPlayer && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0.0f){
                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x,collision.gameObject.GetComponent<player>().jumpPower*1.5f);
                    point_add.AddPoints(Random.Range(10,40),transform.position,pointObject);
                    hits -= 1;
                    if (hits == 0)
                    {
                        Destroy(gameObject);
                    }
                    nextDamage = Time.time + 2;
                }
                else{
                    player.TakeDamage(damage);
                    nextDamage = Time.time + 2;
                }
            }
        }
    }
}
