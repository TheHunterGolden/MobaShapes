﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour {
    public Vector3 direction;
    public float speed;
    public float range;
    public float distance;

    void Start()
    {
        distance = 0f;
    }

    void Update () {
        transform.localPosition += direction * speed * Time.deltaTime;
        distance += direction.magnitude * speed * Time.deltaTime;

        if(distance > range)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "square" && collision.gameObject.tag != "enemy" && collision.gameObject.tag != "playerAttack")
            direction = Vector3.Reflect(direction, collision.contacts[0].normal).normalized;
    }
}
