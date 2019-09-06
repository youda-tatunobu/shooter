using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sideRotate : MonoBehaviour
{
    [SerializeField]
    GameObject fireball = null;

    [SerializeField]
    BossHP  main;

    [SerializeField]
    float ANGV = 90;

    [SerializeField]
    int count = 3;

    float shootwait;
    float pos = 0.0f;
    int time = 300;
  
    float a = 1.0f;
    public int sideHP = 200;
    int Bonus=150;
    int stop = 0;





    // Start is called before the first frame update
    void Start()
    {
        Vector3 move = transform.position;
        shootwait = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
        switch(BossHP.nextstage)
        {
            case 0:
                DNMK0();
                break;

            case 1:
                DNMK1();
                break;
                
        }

    }

    void DNMK0()
    {

        if(stop!=0||(count ==0))
        {
            
           
            return;
        }

        if (time <= 0)
        {
            stop = 0;
            
            Vector3 move = transform.position;
            shootwait -= Time.deltaTime;
            if (shootwait<=0)
            {

                Instantiate(fireball, move, transform.rotation);
                Instantiate(fireball, move, Quaternion.Euler(0,0,180)*transform.rotation);


                shootwait += 1f / (float)count;
            }
            
            pos = Mathf.Repeat(pos + ANGV*Time.deltaTime, 360);
            transform.rotation = Quaternion.Euler(0, 0, pos);
        }
        time--;
    }

    void DNMK1()
    {
        time++;
        if (time <= 60)
        {
            sideHP = 200;
            pos = -120;
            count = 0;
            Bonus = 1;
            return;

        }
        Vector3 move = transform.position;

        stop = 0;
        if (count >= 2)
        {

            Instantiate(fireball, move, transform.rotation);
            


            count = 0;
        }
        count++;


        pos += a;

        transform.Rotate(new Vector3(0, 0, pos));
        if (pos >= -140 || pos >= 140)
        {
            a *= -1;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(sideHP<=0)
        {
            return;
        }
        if (other.CompareTag("ball"))
        {
            sideHP--;
            
            if(sideHP<=0|| main.Bosshp<=0)
            {
                main.damege(Bonus);

                stop=1;

                

            }
        }

    }

}



