using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUseR : MonoBehaviour {
    public bool activated;
    public bool back;
    public float lastingTime;
    public float speed;
    public float rotateSpeed;
    public float distance;
    public float startTime;
    public GameObject prefabAttackCude;
    public Transform cubeManTransform;
    public GameObject[] attackCude;
    public GameObject qCdTimer;
    public SkillUseQ qSkill;
    public Quaternion rotation;
    public Vector3[] relativeDistance;

    void Start()
    {
        activated = false;
        back = false;
        attackCude = new GameObject[4];
        relativeDistance = new Vector3[4];
    }

    void LateUpdate()
    {
        if (activated)
        {
            for (int i = 0; i < attackCude.Length; i++)
            {
                attackCude[i].transform.position = cubeManTransform.position + relativeDistance[i];
                attackCude[i].transform.RotateAround(cubeManTransform.position, Vector3.up, rotateSpeed * Time.deltaTime);
                relativeDistance[i] = attackCude[i].transform.position - cubeManTransform.position;
            }
        }
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
                qSkill.isR = false;
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
            for (int i = 0; i < attackCude.Length; i++)
            {
                attackCude[i] = Instantiate(prefabAttackCude, cubeManTransform);
                attackCude[i].transform.parent = null;
            }

            attackCude[0].transform.position = new Vector3(cubeManTransform.position.x + distance, 2f, cubeManTransform.position.z);
            attackCude[1].transform.position = new Vector3(cubeManTransform.position.x - distance, 2f, cubeManTransform.position.z);
            attackCude[2].transform.position = new Vector3(cubeManTransform.position.x, 2f, cubeManTransform.position.z + distance);
            attackCude[3].transform.position = new Vector3(cubeManTransform.position.x, 2f, cubeManTransform.position.z - distance);

            for (int i = 0; i < attackCude.Length; i++)
            {
                relativeDistance[i] = attackCude[i].transform.position - cubeManTransform.position;
            }

            startTime = Time.time;

            activated = true;
            qSkill.isR = true;
        }
    }
}
