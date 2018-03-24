using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUseQ : MonoBehaviour {
    public bool activated;
    public bool back;
    public float lastingTime;
    public float speed;
    public float maxDistance;
    public Vector3 startPos;
    public float startTime;
    public Vector3 desPos;
    public GameObject prefabAttackCude;
    public Transform cubeManTransform;
    public GameObject attackCude;
    public GameObject cdTimer;
    
	void Start () {
        activated = false;
        back = false;
	}
	
	void Update () {
        if (activated)
        {
            float diff = Vector3.Distance(startPos, attackCude.transform.localPosition);

            if (diff < maxDistance && attackCude.transform.localPosition.x > -96f && attackCude.transform.localPosition.x < 96f && attackCude.transform.localPosition.z > -199f && attackCude.transform.localPosition.z < 199f)
            {
                attackCude.transform.localPosition = Vector3.MoveTowards(attackCude.transform.localPosition, desPos, speed * Time.deltaTime);
            }

            if(Time.time - startTime > lastingTime)
            {
                Destroy(attackCude);
                activated = false;

                float remainingTime = cdTimer.GetComponent<CooldownTimer>().cooldown - lastingTime;
                cdTimer.GetComponent<Text>().text = remainingTime.ToString();
                cdTimer.GetComponent<CooldownTimer>().canUse = false;
            }
        }
        if (back)
        {
            attackCude.transform.localPosition = Vector3.MoveTowards(attackCude.transform.localPosition, cubeManTransform.localPosition, speed * Time.deltaTime);

            if (Vector3.Distance(cubeManTransform.localPosition, attackCude.transform.localPosition) == 0f)
            {
                Destroy(attackCude);
                back = false;
            }
        }
	}

    public void QUse()
    {
        if (!activated)
        {
            attackCude = Instantiate(prefabAttackCude, cubeManTransform);
            attackCude.transform.parent = null;
            startPos = attackCude.transform.localPosition;
            startTime = Time.time;

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                desPos = new Vector3(hit.point.x, cubeManTransform.position.y, hit.point.z);
            }

            activated = true;
        }
        else if (activated)
        {
            back = true;
            activated = false;

            float remainingTime = cdTimer.GetComponent<CooldownTimer>().cooldown - (Time.time - startTime);
            cdTimer.GetComponent<Text>().text = remainingTime.ToString();
            cdTimer.GetComponent<CooldownTimer>().canUse = false;
        }
    }
}
