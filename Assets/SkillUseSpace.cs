using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUseSpace : MonoBehaviour {
    public bool activated;
    public GameObject prefabShield;
    public float lastingTime;
    public float startTime;
    public Transform cubeManTransform;
    public GameObject shield;

    void Start () {
        activated = false;
	}
	
	void Update () {
		if (activated && Time.time - startTime > lastingTime)
        {
            Destroy(shield);
            activated = false;
        }
	}

    public void SpaceUse()
    {
        shield = Instantiate(prefabShield, cubeManTransform);
        startTime = Time.time;
        activated = true;
    }
}
