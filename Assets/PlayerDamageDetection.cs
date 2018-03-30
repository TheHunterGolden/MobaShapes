using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetection : MonoBehaviour {
    public GameObject gameOver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemyAttack")
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
