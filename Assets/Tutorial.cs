using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public string move;
    public bool moveDetect;
    public string abilityInfo;
    public string swordAttck;
    public string abilityQ1;
    public string abilityQ2;
    public string abilitySpace1;
    public string abilitySpace2;
    public string abilityE;
    public string abilityR1;
    public string abilityR2;
    public int order;
    public Text tutorial;
    public WaveManager waveManager;
    public GameObject[] harmlessEnemy;
    public GameObject[] abilityInfos;
    //public AbilityManager abilityManager;
    public Animator[] enemyAnimator;
    public CooldownTimer[] cd;
    public GameObject scoreBar;
    public WasdMovement movement;
    public SkillUseQ abilityQ;
    public SkillUseR abilityR;
    public PlayerDamageDetection playerDamageDetection;

    // Use this for initialization
    void Start () {
        moveDetect = false;
        order = 0;

        move = "Use WASD to move and Mouse to aim";
        abilityInfo = "Hover over the ability icon to read the abilityInfo";
        swordAttck = "LeftClick to use swordAttack to kill the enemy!";
        abilityQ1 = "Use Q to kill the enemy";
        abilityQ2 = "Use Q to pull back the attack cube";
        abilitySpace1 = "Use Space to block the attack";
        abilitySpace2 = "Use Reflected attack to kill the enemy";
        abilityE = "Use E to dash and kill the enemy";
        abilityR1 = "Use R to kill the enemy";
        abilityR2 = "Use Q to pull back the attack cube";

        //abilityManager.enabled = false;
        scoreBar.SetActive(false);
        movement.enableSwordAttack = false;

        for (int i = 0; i < cd.Length; i++)
        {
            cd[i].canUse = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (order)
        {
            case 0: tutorial.text = move;
                MoveCheck();
                break;
            case 1: tutorial.text = abilityInfo;
                AbilityInfoCheck();
                break;
            case 2: tutorial.text = swordAttck;
                SwordAttackCheck();
                break;
            case 3: tutorial.text = abilityQ1;
                AbilityQ1Check();
                break;
            case 4: tutorial.text = abilityQ2;
                AbilityQ2Check();
                break;
            case 5: tutorial.text = abilitySpace1;
                AbilitySpace1Check();
                break;
            case 6: tutorial.text = abilitySpace2;
                AbilitySpace2Check();
                break;
            case 7: tutorial.text = abilityE;
                AbilityECheck();
                break;
            case 8: tutorial.text = abilityR1;
                AbilityR1Check();
                break;
            case 9:
                tutorial.text = abilityR2;
                AbilityR2Check();
                break;
            case 10: waveManager.enabled = true;
                movement.enableSwordAttack = true;

                for(int i = 0; i < cd.Length; i++)
                {
                    cd[i].canUse = true;
                }

                playerDamageDetection.isTutorial = false;
                scoreBar.SetActive(true);
                scoreBar.GetComponent<Scorebar>().score = 0;
                gameObject.SetActive(false);
                break;
        }
	}

    public void MoveCheck()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (moveDetect)
                order++;

            moveDetect = true;
        }
    }

    public void AbilityInfoCheck()
    {
        for (int i = 0; i < abilityInfos.Length; i++)
        {
            if (abilityInfos[i].activeSelf)
            {
                harmlessEnemy[0].SetActive(true);
                order++;
            }
        }
    }

    public void SwordAttackCheck()
    {
        if (enemyAnimator[0].GetBool("Attacked"))
        {
            cd[0].canUse = true;
            movement.enableSwordAttack = false;
            harmlessEnemy[1].SetActive(true);
            order++;
        }
    }

    public void AbilityQ1Check()
    {
        if (enemyAnimator[1].GetBool("Attacked"))
        {
            cd[0].canUse = true;
            movement.enableSwordAttack = false;
            order++;
        }
    }

    public void AbilityQ2Check()
    {
        if (abilityQ.back)
        {
            cd[0].canUse = false;
            cd[1].canUse = true;
            harmlessEnemy[2].SetActive(true);
            order++;
            playerDamageDetection.isTutorial = true;
        }
    }

    public void AbilitySpace1Check()
    {
        ShielRelfection sr = playerDamageDetection.gameObject.GetComponentInChildren<ShielRelfection>();
        if (sr != null && sr.blocked)
        {
            order++;
        }
    }

    public void AbilitySpace2Check()
    {
        if (enemyAnimator[2].GetBool("Attacked"))
        {
            cd[1].canUse = false;
            cd[2].canUse = true;
            order++;
            harmlessEnemy[3].SetActive(true);
        }
    }

    public void AbilityECheck()
    {
        if (enemyAnimator[3].GetBool("Attacked"))
        {
            harmlessEnemy[4].SetActive(true);
            cd[2].canUse = false;
            cd[3].canUse = true;
            order++;
        }
    }

    public void AbilityR1Check()
    {
        if (enemyAnimator[4].GetBool("Attacked"))
        {
            order++;
            cd[0].canUse = true;
        }
    }

    public void AbilityR2Check()
    {
        if (abilityR.back)
        {
            order++;
        }
    }
}
