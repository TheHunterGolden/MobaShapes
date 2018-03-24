using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

public class AbilityManager : MonoBehaviour {

    public GameObject[] abilities;
    public GameObject onCooldownFeedback;
    void Start() {
        
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q)) {
            
            if (abilities[0].GetComponentInChildren<CooldownTimer>().canUse == true)
            {
                abilities[0].GetComponentInChildren<SkillUseQ>().QUse();
                //abilities[0].GetComponentInChildren<CooldownTimer>().startCoolDown();
                Debug.Log("q ability used");
            }
            else {
                Debug.Log("on cooldown");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (abilities[1].GetComponentInChildren<CooldownTimer>().canUse == true)
            {
                abilities[1].GetComponentInChildren<SkillUseSpace>().SpaceUse();
                abilities[1].GetComponentInChildren<CooldownTimer>().startCoolDown();
                Debug.Log("Space ability used");
            }
            else
            {
                Debug.Log("on cooldown");
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (abilities[2].GetComponentInChildren<CooldownTimer>().canUse == true)
            {
                abilities[2].GetComponentInChildren<SkillUseE>().EUse();
                abilities[2].GetComponentInChildren<CooldownTimer>().startCoolDown();
                Debug.Log("E ability used");
            }
            else
            {
                Debug.Log("on cooldown");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (abilities[3].GetComponentInChildren<CooldownTimer>().canUse == true)
            {
                abilities[3].GetComponentInChildren<CooldownTimer>().startCoolDown();
                Debug.Log("R ability used");
            }
            else
            {
                Debug.Log("on cooldown");
            }
        }

    }

}
