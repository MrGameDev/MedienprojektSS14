﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public bool moveLeft;
    public float speed;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 movement;

	    if (moveLeft)
        {
            movement = new Vector3(-Time.deltaTime*speed, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(Time.deltaTime*speed, 0.0f, 0.0f);
        }

        transform.position += movement;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBorder")
        {
            moveLeft = !moveLeft;
        }
        else if (other.tag == "Head")
        {
            Head head = other.GetComponent<Head>();
            Segment segment = head.successor;

            if (segment == null)
            {
                Destroy(head.gameObject); 
                //show game over screen
            }

            while (segment.successor != null)
            {
                segment = segment.successor;
            }

            Destroy(segment.gameObject);
        }
        else if (other.tag == "Segment")
        {
            Segment segment = other.GetComponent<Segment>();
            
            while (segment.successor != null)
            {
                segment = segment.successor;
            }

            Destroy(segment.gameObject);
        }
    }
}
