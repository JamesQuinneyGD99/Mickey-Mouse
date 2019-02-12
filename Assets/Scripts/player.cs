using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    static float health;
    static Transform healthBar;
    static float nextDamage;
    public float nextFlicker;
    public static int points;
    public Rigidbody2D rb;
    public float speed;
    public float jumpPower;
    public int jumps;
    public GameObject deadPanel;
    static GameObject deadPanelStatic;
    public GameObject sprite;

    public Animator anim;
    public Sprite idleSprite;
    public SpriteRenderer spriteRender;

    public static void AddHealth(float amount){
        health = Mathf.Clamp(health + amount,0.0f,100.0f);
        healthBar.localScale = new Vector2(0.34f-Mathf.Clamp(0.34f*health/100.0f,0.0f,0.34f),1.0f);
    }

    public static void TakeDamage(float amount){
        if(Time.time>nextDamage){
            nextDamage = Time.time + 1;
            AddHealth(-amount);

            if(health <= 0.0f)
            {
                deadPanelStatic.SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health Bar").transform;
        deadPanelStatic = deadPanel;
        AddHealth(100.0f);
        jumps = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * speed;

        rb.velocity = new Vector2(xAxis,rb.velocity.y);

        if(xAxis > 0){
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x),Mathf.Abs(transform.localScale.y));
        }
        else if(xAxis < 0){
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x),Mathf.Abs(transform.localScale.y));
        }
        
        if(Input.GetButtonDown("Jump")){
            if(jumps>0){
                jumps -= 1;

                rb.velocity = new Vector2(rb.velocity.x,jumpPower);
            }
        }

        if(xAxis==0.0f){
            anim.enabled = false;
            spriteRender.sprite = idleSprite;
        }
        else{
            anim.enabled = true;
            anim.SetFloat("speed",Mathf.Abs(xAxis));
        }

        Camera.main.transform.position = transform.position - new Vector3(0.0f,0.0f,10.0f);

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
}
