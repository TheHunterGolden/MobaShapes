using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

    NavMeshAgent agent;
    public Transform playerLoc;
    private Animator _animator;
    private bool inRange;
    public Transform bulletSpawn;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
        inRange = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (!_animator.GetBool("Attacked"))
            gameObject.transform.LookAt(playerLoc);

        if (inRange == true)
        {
            Attack();
        }
        else {
            chase();
        }
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.name == "SquarePerson")
        {
            agent.destination = gameObject.transform.position;

            inRange = true;
            
        }
       
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "square") {
            inRange = false;
            _animator.SetBool("Attacking", false);
        }
    }

    void Attack() {
        _animator.SetBool("Attacking", true);
         
    }

    void chase() {
        agent.destination = playerLoc.position;
    }
}
