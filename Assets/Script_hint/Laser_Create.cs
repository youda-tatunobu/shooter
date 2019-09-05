using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Create : MonoBehaviour {

    public GameObject Laser_prefab;//Laser_prefabをインスペクターに用意
    public GameObject Cube_prefab;
    public static int collision = 0;
    private int collision_time = 0;
    
    void Cube_Create()//壁生成   
    {      
        for (int i = 0; i < 5; i++)
        {          
            for (int j = 0; j < 5; j++)
            {               
                for (int k = 0; k < 7; k++)
                {
                    Cube_color.color = Random.Range(0, 6);//壁の色
                    Instantiate(Cube_prefab, new Vector3(j - 2, i - 2, k -3), Quaternion.identity);//壁生成                   
                }
            }
        }
    }
    void Start () {
        Cube_Create();//壁生成   
    }
	
	void Update () {
        if(collision==1 && collision_time==0)
        {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 120);//弾に当たったら赤に変更する
        }
        
        if(collision==1)
        {
            collision_time++;
        }

        if(collision_time > 5)
        {
            collision = 0;
            collision_time = 0;
            GetComponent<Renderer>().material.color = new Color32(30, 255, 200, 120);//元の色に戻す
        }

        Vector3 touchScreenPosition = Input.mousePosition;//マウス座標を代入

        touchScreenPosition.z = 3.6f;

        Camera gameCamera = Camera.main;//カメラ取得
        Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);//マウス座標をワールド座標に変換

        Vector3 pos = transform.position;
        pos.x = touchWorldPosition.x;
        pos.y = touchWorldPosition.y;
        pos.z = touchWorldPosition.z;

        transform.position = pos;//プレイヤー表示座標


        if (Input.GetMouseButton(0))//マウスを左クリックした時
        {
            touchScreenPosition.z = 5f;
            touchWorldPosition = gameCamera.ScreenToWorldPoint(touchScreenPosition);
            Debug.Log("LeftClick:" + touchWorldPosition);//取得座標表示
           
            Instantiate(Laser_prefab, touchWorldPosition , Quaternion.identity);//左クリック位置にレーザー生成
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cube_Create();//右クリック時、壁生成
        }

    }
}
