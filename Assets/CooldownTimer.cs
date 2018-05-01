using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour {

    private float cooldownTimer;
    public float cooldown;
    public bool canUse;
    public float startTime;

    void start () {
        //gameObject.GetComponent<Text>().text = "0";
        canUse = true;     	
	}
	
	// Update is called once per frame
	void Update () {

        /*if (gameObject.GetComponent<Text>().text != "" && float.Parse(gameObject.GetComponent<Text>().text) > 0)
        {
            
            gameObject.GetComponent<Text>().text = (float.Parse(gameObject.GetComponent<Text>().text) - Time.deltaTime).ToString();
            
        }
        
        if (gameObject.GetComponent<Text>().text != "" &&  float.Parse(gameObject.GetComponent<Text>().text) <= 0)
        {
            gameObject.GetComponent<Text>().text = "";
            canUse = true;
        }*/

        if (gameObject.GetComponent<Image>().enabled)
        {
            gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0f, (Time.time - startTime) / cooldown);
        }
        
        if(gameObject.GetComponent<RectTransform>().anchorMin.y >= 1f)
        {
            gameObject.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            gameObject.GetComponent<Image>().enabled = false;
            canUse = true;
        }
    }

    public void startCoolDown() {
        //gameObject.GetComponent<Text>().text = cooldown.ToString();
        canUse = false;

        gameObject.GetComponent<Image>().enabled = true;
        startTime = Time.time;
    }

}
