using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stair_trigger_flicker : MonoBehaviour
{
    int flickerDelay = 6;
    float nextFlicker;
    public SpriteRenderer backgroundSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextFlicker != 0.0f && Time.time > nextFlicker && flickerDelay != 0)
        {
            flickerDelay = Mathf.FloorToInt(flickerDelay / 1.1f);
            nextFlicker = Time.time + flickerDelay;

            backgroundSprite.color = new Color(Mathf.Abs(backgroundSprite.color.r-1.0f), Mathf.Abs(backgroundSprite.color.r - 1.0f), Mathf.Abs(backgroundSprite.color.r - 1.0f), 1.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && nextFlicker == 0)
        {
            nextFlicker = Time.time;
        }
    }
}
