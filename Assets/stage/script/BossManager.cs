using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    Rigidbody rb;

   

    



    // Start is called before the first frame update
    void move()
    { 
            rb = GetComponent<Rigidbody>();
            Vector2 a = new Vector3(0, 2.5f, 0).normalized;
            rb.velocity = -a ;


    }

    // Update is called once per frame
    void Update()
    {
        switch(BossHP.nextstage)
        { 
            case 0:
                move();
                if (transform.position.y <= 2.5f)
                {
                    rb.velocity = Vector3.zero;
                }
                
            break;

            case 1:
                move();
                if (transform.position.y <= 0.0f)
                {
                    rb.velocity = Vector3.zero;
                }
               
                break;
        }

       


    }

}
