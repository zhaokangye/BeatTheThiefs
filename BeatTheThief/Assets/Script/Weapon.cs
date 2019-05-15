﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "AirWall":
                Destroy(gameObject);
                break;
            case "Furniture":
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.SendMessage("GetHit");
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
