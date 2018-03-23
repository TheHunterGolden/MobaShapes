using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {
    public Transform toLookAt;

	void Update () {
        gameObject.transform.LookAt(toLookAt);	
	}
}
