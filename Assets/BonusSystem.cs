using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusSystem : MonoBehaviour {
    public int currentBonus;
    public Text instr;
    public GameObject squareMan;
    public GameObject[] enemies;
    public Scorebar scoreBar;
    public float startTime;
    public float lastingTime;
    public bool isNoKilling;
    public int[] chosenEnemy;
    public GameObject prefabArrow;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        currentBonus = Random.Range(0, 6);
        InstrChange();
        isNoKilling = false;
        chosenEnemy = null;
    }
	
	// Update is called once per frame
	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        InstrChange();
    }

    public void InstrChange()
    {
        string remainingTime = (lastingTime - Time.time + startTime).ToString("0");

        switch (currentBonus)
        {
            case 0:
                instr.text = "Sword attack bonus! " + remainingTime + "s";
                break;
            case 1:
                remainingTime = (lastingTime * 2 / 3 - Time.time + startTime).ToString("0");
                instr.text = "Cube attack bonus! " + remainingTime + "s";
                break;
            case 2:
                instr.text = "Reflected attack bonus! " + remainingTime + "s";
                break;
            case 3:
                instr.text = "Dash attack bonus! " + remainingTime + "s";
                break;
            case 4:
                remainingTime = "-1";
                string waitingTime = (lastingTime / 3 - Time.time + startTime).ToString("0");
                if (!isNoKilling)
                {
                    isNoKilling = true;
                    InvokeRepeating("NoKillingBonus", lastingTime / 3 + 4.4F, 5F);
                }
                    
                if ((lastingTime / 3 - Time.time + startTime) > 0)
                    instr.text = "No killing bonus! Start after " + waitingTime + "s...";
                else
                {
                    remainingTime = (lastingTime / 3 - Time.time + startTime + lastingTime).ToString("0");
                    instr.text = "No killing bonus every 5 seconds! " + remainingTime +"s";
                }
                
                break;
            case 5:
                if (enemies.Length == 0)
                {
                    BonusChange();
                }
                else
                {
                    if (chosenEnemy == null)
                    {
                        int numbers = Random.Range(1, 4);
                        if (numbers > enemies.Length)
                            numbers = enemies.Length;
                        chosenEnemy = new int[numbers];

                        for (int i = 0; i < chosenEnemy.Length; i++)
                        {
                            chosenEnemy[i] = Random.Range(0, enemies.Length);
                            for(int j = 0; j < chosenEnemy.Length; j++)
                            {
                                if (i != j && chosenEnemy[i] == chosenEnemy[j])
                                {
                                    i--;
                                    break;
                                }    
                            }
                        }

                        for (int i = 0; i < chosenEnemy.Length; i++)
                        {
                            Instantiate(prefabArrow, enemies[chosenEnemy[i]].transform);
                        }
                    }

                    bool allCleared = true;
                    GameObject[] pointedEnemies = GameObject.FindGameObjectsWithTag("arrow");
                    for (int i = 0; i < pointedEnemies.Length; i++)
                    {
                        Animator aniEnemy = pointedEnemies[i].transform.parent.GetComponentInChildren<Animator>();
                        if(!aniEnemy.GetBool("Attacked")){
                            allCleared = false;
                            break;
                        }
                    }

                    if (allCleared)
                    {
                        scoreBar.score += chosenEnemy.Length * 4;
                        BonusChange();
                        chosenEnemy = null;
                    }
                    else
                    {
                        remainingTime = (lastingTime - Time.time + startTime).ToString("0");
                        instr.text = "Eliminate pointed enemies! " + remainingTime + "s";
                    }
                }

                break;
        }

        if (int.Parse(remainingTime) == 0 && (currentBonus != 4 || isNoKilling))
        {
            if(currentBonus == 4)
            {
                isNoKilling = false;
                CancelInvoke();
            }

            if(currentBonus == 5)
            {
                GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
                for(int i = 0; i < arrows.Length; i++)
                {
                    Destroy(arrows[i]);
                }
            }

            BonusChange();
        }
    }

    public void NoKillingBonus()
    {
        if (enemies.Length / 2 == 0 || enemies.Length / 2 == 1)
            scoreBar.score += 1f;
        else
            scoreBar.score += enemies.Length / 2;
    }

    public void BonusChange()
    {
        startTime = Time.time;
        int lastBonus = currentBonus;
        while (currentBonus == lastBonus)
            currentBonus = Random.Range(4, 6);
    }

    public void BonusCheck(int deathType)
    {
        if (deathType == currentBonus)
            scoreBar.score += PointsByType(deathType);

        if(currentBonus == 4 && (lastingTime / 3 - Time.time + startTime) <= 0)
        {
            isNoKilling = false;
            BonusChange();
            CancelInvoke();
        }
    }

    public int PointsByType(int deathType)
    {
        switch (deathType)
        {
            case 0: return 3;
            case 1: return 1;
            case 2: return 2;
            case 3: return 2;
        }

        return 0;
    }
}
