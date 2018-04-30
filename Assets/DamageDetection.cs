using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DamageDetection : MonoBehaviour {
    public Animator enemyAnimator;
    public Animator playerAnimator;
    public Text scorebar;
    public AudioClip[] deathSounds;
    public AudioSource source;
    public BonusSystem bonus;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "playerAttack" || (collision.gameObject.name == "Sword"))
        {
            source.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NavMeshAgent>().speed = 0f;
            enemyAnimator.SetBool("Attacked", true);
            
            scorebar.GetComponent<Scorebar>().addScore();

            int deathType = -1;

            if (collision.gameObject.name == "Sword")
            {
                deathType = 0;
            }
            else if (collision.gameObject.name.Substring(0, 10) == "AttackCube")
            {
                deathType = 1;
            }
            else if (collision.gameObject.name.Substring(0, 6) == "Bullet")
            {
                deathType = 2;
            }
            else if (collision.gameObject.name.Substring(0, 12) == "SquarePerson")
            {
                deathType = 3;
            }

            bonus.BonusCheck(deathType);
        }
    }
}
