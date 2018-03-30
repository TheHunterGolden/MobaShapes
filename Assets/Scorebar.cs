using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scorebar : MonoBehaviour {

    Text scoreboard;
    public float score;

	void Start () {
        scoreboard = gameObject.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        

        scoreboard.text = "Score: " + score;

	}

    public void addScore() {
        score += 1;
    }

}
