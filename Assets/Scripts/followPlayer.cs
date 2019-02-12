using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player !=null && Vector3.Distance(player.transform.position, transform.position) < 5.0f)
        {
            if (player.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(1.0f, rb.velocity.y);
                sprite.transform.localScale = new Vector2(Mathf.Abs(sprite.transform.localScale.x), Mathf.Abs(sprite.transform.localScale.y));
            }
            else if (player.transform.position.x + 0.2f < transform.position.x)
            {
                rb.velocity = new Vector2(-1.0f, rb.velocity.y);
                sprite.transform.localScale = new Vector2(-Mathf.Abs(sprite.transform.localScale.x), Mathf.Abs(sprite.transform.localScale.y));
            }
        }
    }
}
