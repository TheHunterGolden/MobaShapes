using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorial : MonoBehaviour {
    public GameObject tutorial;
    public GameObject target;
    public GameObject bonus;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        Cursor.visible = true;
	}

    public void Yes()
    {
        target.SetActive(true);
        Time.timeScale = 1;
        bonus.SetActive(true);
        gameObject.SetActive(false);
    }

    public void No()
    {
        tutorial.SetActive(true);
        target.SetActive(true);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
