using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielRelfection : MonoBehaviour {
    public bool blocked;

    private void Start()
    {
        blocked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyAttack")
        {
            collision.gameObject.tag = "playerAttack";
            blocked = true;
        }
    }
}
