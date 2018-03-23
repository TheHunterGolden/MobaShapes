using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 velocity = Vector3.zero;
    public float distanceUp;
    public float distanceBack;
    public float dampSpeed;
    public float distanceForward;

    // Update is called once per frame
    void Update()
    {

        if (playerTransform != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, playerTransform.position + new Vector3(distanceForward,distanceUp,distanceBack), ref velocity, dampSpeed);
        }
    }

    public void setTarget(Transform target)
    {
        playerTransform = target;
    }
}
