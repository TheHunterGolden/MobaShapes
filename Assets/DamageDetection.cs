using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DamageDetection : MonoBehaviour {
    public Animator enemyAnimator;
    public Animator playerAnimator;
    public Text scorebar;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "playerAttack" || (collision.gameObject.name == "Sword" && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack")))
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<NavMeshAgent>().speed = 0f;
            enemyAnimator.SetBool("Attacked", true);
            scorebar.GetComponent<Scorebar>().addScore();
        }
    }
}
