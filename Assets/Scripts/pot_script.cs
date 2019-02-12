using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot_script : MonoBehaviour
{
    GameObject hiding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && hiding != null)
        {
            hiding.SetActive(true);
            hiding.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
            hiding = null;
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.0f)
        {
            {
                collider.gameObject.SetActive(false);
                hiding = collider.gameObject;
            }
        }
    }
}
