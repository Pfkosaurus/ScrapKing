using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mete : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(transform.gameObject);
        }
        
    }
}
