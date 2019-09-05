using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossball : MonoBehaviour
{
    Rigidbody rb;
    public int speed = 3;
    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {

        time++;
        if (time > 200)//600フレーム後に弾削除
        {
            transform.DetachChildren();//親オブジェクトから子オブジェクトを解除
            Destroy(gameObject);//弾削除
        }
    }
}
