using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Animator _animator;
    NavMeshAgent agent;

    public Transform playerLoc;

    public BulletSpawn bulletSpawn;
   
    // Use this for initialization
    void Start () {

        _animator = GetComponentInChildren<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        agent.destination = playerLoc.position;

    }
	
	// Update is called once per frame
	void Update () {
        
        _animator.SetFloat("velZ", agent.velocity.magnitude);
	}
    
   
}
