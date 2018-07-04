using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour {

    public GameObject pink2;
    public GameObject Des;
    float x = Random.Range(0, 360);

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ex")
        {
            Instantiate(pink2, gameObject.transform.position, Quaternion.identity);
            Instantiate(Des, gameObject.transform.position, Quaternion.Euler(0, Random.Range(-360, 360), 0));
            Destroy(gameObject);
        }
        if (other.tag == "JK")
        {
            Destroy(gameObject);
        }
    }
}