using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy1 : MonoBehaviour {
    float time;
    
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            Destroy(gameObject);
        }
    }
}