using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    float time;
    
	void Update () {
        time += Time.deltaTime;
        if (time > 1)
        {
            Destroy(gameObject);
        }
	}
}
