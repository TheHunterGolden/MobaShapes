using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielRelfection : MonoBehaviour {
    public bool blocked;
    public AudioClip blockSounds;
    public AudioSource source;

    private void Start()
    {
        blocked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyAttack")
        {
            collision.gameObject.tag = "playerAttack";
            source.PlayOneShot(blockSounds);
            
            blocked = true;
        }
    }
}
