﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{

    Rigidbody rb;

    float speed = 5;
    int count = 0;
    int tiam = 0;
    int d = 0;
    public int a = 0;

    [SerializeField]
    GameObject ball = null;

    [SerializeField]
    Position Imeage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
  void Update()
    {

        Vector3 move = transform.position;

        if (Input.GetMouseButton(0)||Input.GetButton("shoot_z"))
        {
            if(Input.GetButton("shoot_z"))
            {
                Position.a=1;
                

            }
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3.5f;
        }

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move.z = 0;
        rb.velocity = move * speed;
        speed = 5;



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fireball"))
        {

            if (a == 5)
            {
                SceneManager.LoadScene("Last");
            }
            a++;

        }
    }

}