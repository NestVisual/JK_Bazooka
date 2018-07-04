using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy3 : MonoBehaviour {

    float time;
    public float accel;

    private void Start()
    {
        Vector3 v = new Vector3(Random.Range(-90, 90), Random.Range(0, 360), Random.Range(-90, 90));
        GetComponent<Rigidbody>().AddForce(v * accel, ForceMode.Impulse);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 7)
        {
            Destroy(gameObject);
        }
    }
}
