using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    public int Bosshp = 200;
    int frag = 0;
    public static int nextstage = 0;
    // Start is called before the first frame update
    void Start()
    {
         switch (nextstage)
        {
            case 0:
                break;
            case 1:
                frag = 1;
                Bosshp = 2;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ball")&&frag==0)
        {
            
            damege(1);
        }
        
    }

    public void damege(int b)
    {
        Bosshp -= b;
        if(Bosshp<=0)
        {
            nextstage++;
            Start();

        }
    }
}
