using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUseR : MonoBehaviour {
    public bool activated;
    public bool back;
    public float lastingTime;
    public float speed;
    public float distance;
    public float startTime;
    public GameObject prefabAttackCude;
    public Transform cubeManTransform;
    public GameObject[] attackCude;
    public GameObject qCdTimer;
    public SkillUseQ qSkill;

    void Start()
    {
        activated = false;
        back = false;
        attackCude = new GameObject[4];
    }

    void Update()
    {
        if (activated && !back)
        {
            if (Time.time - startTime > lastingTime)
            {
                Destroy(attackCude[0]);
                Destroy(attackCude[1]);
                Destroy(attackCude[2]);
                Destroy(attackCude[3]);
                activated = false;
            }
        }
        if (back)
        {
            attackCude[0].transform.localPosition = Vector3.MoveTowards(attackCude[0].transform.localPosition, Vector3.zero, speed * Time.deltaTime);
            attackCude[1].transform.localPosition = Vector3.MoveTowards(attackCude[1].transform.localPosition, Vector3.zero, speed * Time.deltaTime);
            attackCude[2].transform.localPosition = Vector3.MoveTowards(attackCude[2].transform.localPosition, Vector3.zero, speed * Time.deltaTime);
            attackCude[3].transform.localPosition = Vector3.MoveTowards(attackCude[3].transform.localPosition, Vector3.zero, speed * Time.deltaTime);

            if (Vector3.Equals(attackCude[0].transform.localPosition, Vector3.zero))
            {
                Destroy(attackCude[0]);
                Destroy(attackCude[1]);
                Destroy(attackCude[2]);
                Destroy(attackCude[3]);
                back = false;
                activated = false;
            }
        }
    }

    public void RUse()
    {
        if (!activated)
        {
            attackCude[0] = Instantiate(prefabAttackCude, cubeManTransform);
            attackCude[1] = Instantiate(prefabAttackCude, cubeManTransform);
            attackCude[2] = Instantiate(prefabAttackCude, cubeManTransform);
            attackCude[3] = Instantiate(prefabAttackCude, cubeManTransform);

            attackCude[0].transform.localPosition += new Vector3(distance, 0, distance);
            attackCude[1].transform.localPosition += new Vector3(distance, 0, -distance);
            attackCude[2].transform.localPosition += new Vector3(-distance, 0, distance);
            attackCude[3].transform.localPosition += new Vector3(-distance, 0, -distance);

            startTime = Time.time;

            activated = true;
            qSkill.activated = true;
            qSkill.isR = true;
        }
    }
}
