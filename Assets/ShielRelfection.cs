using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielRelfection : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyAttack")
        {
            collision.gameObject.tag = "playerAttack";
            collision.gameObject.layer = 0;
        }
    }
}
