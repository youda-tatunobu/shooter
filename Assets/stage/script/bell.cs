using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bell : MonoBehaviour
{
    public int speed = 10;
    Rigidbody rb;

    int time = 0;
   // public Main main;


    void Start()
    {
        
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;

        GetComponent<Rigidbody>().velocity = transform.up.normalized * speed;

    }
    void Update()
    {
        time++;
        if (time > 200)//600フレーム後に弾削除
        {
            transform.DetachChildren();//親オブジェクトから子オブジェクトを解除
            Destroy(gameObject);//弾削除
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }

}