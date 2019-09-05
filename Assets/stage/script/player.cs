﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Rigidbody rb;

    int speed = 5;
    int count = 0;

    int tiam = 0;

    [SerializeField]
    GameObject ball = null;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
            
    }

    // Update is called once per frame
    void Update()
    {
        Camera gameCamera = Camera.main;
        Vector3 move = transform.position;

        if (Input.GetMouseButton(0))
        {
            if (tiam > 4)
            {

                if (count == 0)
                {
                    move.y = move.y + 0.4f;
                    Instantiate(ball, move, Quaternion.identity);
                    count++;
                    tiam = 0;
                }
                else
                {
                    move.x = move.x + 0.2f;
                    move.z = move.z + 0.2f;
                    Instantiate(ball, move, Quaternion.identity);
                    move.x = move.x - 0.4f;
                    Instantiate(ball, move, Quaternion.identity);
                    count--;
                    tiam = 0;
                }
            }

            tiam++;

        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3;
        }

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move.z = 0;
        rb.velocity = move * speed;
        speed = 5;



        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fireball"))
        {
           
        }
    }

}
