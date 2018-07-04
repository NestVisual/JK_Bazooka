using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour, IInputClickHandler
{
    public GameObject Ball;
    //public GameObject Light;
    float speed = 8;
    public static float x;

    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;
        //RaycastHit hitInfo;

        //if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        //{
            GameObject ball = (GameObject)Instantiate(Ball,headPosition, Camera.main.transform.rotation);
            ball.GetComponent<Rigidbody>().velocity = gazeDirection * speed;
            ball.GetComponent<AudioSource>().enabled = true;
        //Instantiate(Light, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
        //}
    }
}