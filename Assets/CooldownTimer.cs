using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour {

    private float cooldownTimer;
    public float cooldown;
    public bool canUse;

    void start () {
        gameObject.GetComponent<Text>().text = "0";
        canUse = true;     	
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<Text>().text != "" && float.Parse(gameObject.GetComponent<Text>().text) > 0)
        {
            
            gameObject.GetComponent<Text>().text = (float.Parse(gameObject.GetComponent<Text>().text) - Time.deltaTime).ToString();
            
        }
      
        if (gameObject.GetComponent<Text>().text != "" &&  float.Parse(gameObject.GetComponent<Text>().text) <= 0)
        {
            gameObject.GetComponent<Text>().text = "";
            canUse = true;
        }
        
    }

    public void startCoolDown() {
        gameObject.GetComponent<Text>().text = cooldown.ToString();
        canUse = false;
    }

}
