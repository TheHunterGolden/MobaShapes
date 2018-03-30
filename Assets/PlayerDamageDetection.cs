using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetection : MonoBehaviour {
    public GameObject gameOver;
    public SkillUseE abilityE;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemyAttack" && !abilityE.activated)
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
