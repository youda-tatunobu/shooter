using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
   

    Rigidbody2D rb;
    Canvas ca;
    public static int a = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(a==1)
        {
            rb.transform.position = new Vector2(0, 20);
            a = 0;
            return;
        }
        Vector2 mous = rb.transform.position;
        rb.transform.position = Input.mousePosition;
    }

}