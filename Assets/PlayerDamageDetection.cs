using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageDetection : MonoBehaviour {
    public GameObject gameOver;
    public SkillUseE abilityE;
    public bool isTutorial;

    private void Start()
    {
        isTutorial = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemyAttack" && !abilityE.activated && !isTutorial)
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
