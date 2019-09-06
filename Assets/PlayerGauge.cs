using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGauge : MonoBehaviour
{
    SliderJoint2D sl;
    // Start is called before the first frame update
    void Start()
    {
        sl = GetComponent<SliderJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
