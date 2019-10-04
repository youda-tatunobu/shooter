using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageManager : MonoBehaviour
{

    int a = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fireball"))
        {

            if (a == 5)
            {
                SceneManager.LoadScene("Last");
            }
            //a++;

        }
    }
}