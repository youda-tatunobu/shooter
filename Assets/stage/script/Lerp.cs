using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    float speed = 10.0f;
    private float a = 0.0f;
    int count = 0;
    int time = 0;

    Transform Player;
    private GameObject Ship2;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.position;
        Ship2 = GameObject.Find("Ship2");

    }

    // Update is called once per frame
    void Update()
    {
        var move = 1000.0f;
        int ObjCount = Ship2.transform.childCount;
        for (int i = 0; i < ObjCount; i++)
        {

            GameObject ch = this.transform.GetChild(i).gameObject;

            var posP = Vector3.Distance(transform.position, ch.transform.position);
            if (move > posP)
            {
                move = posP;
                count = i;
            }
            a = (Time.deltaTime / speed)/move;
          
            ch = Ship2.transform.GetChild(count).gameObject;

            transform.position = Vector3.Slerp(transform.position, ch.transform.position,a);

        }

        time++;
        if (time > 180)//600フレーム後に弾削除
        {
            transform.DetachChildren();//親オブジェクトから子オブジェクトを解除
            Destroy(gameObject);//弾削除
            
        }

    }
}