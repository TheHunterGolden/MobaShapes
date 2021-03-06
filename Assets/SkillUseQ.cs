﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUseQ : MonoBehaviour {
    public bool activated;
    public bool back;
    public bool isR;
    public float lastingTime;
    public float speed;
    public float maxDistance;
    public Vector3 startPos;
    public float startTime;
    public Vector3 desPos;
    public GameObject prefabAttackCude;
    public Transform cubeManTransform;
    public GameObject attackCude;
    public GameObject qCdTimer;
    public GameObject rCdTimer;
    public SkillUseR rSkill;
    public AudioSource source;
    public AudioClip[] qSounds;
    
	void Start () {
        activated = false;
        back = false;
        isR = false;
	}
	
	void Update () {
        if (activated && !rSkill.activated)
        {
            float diff = Vector3.Distance(startPos, attackCude.transform.localPosition);

            if (diff < maxDistance)
            {
                attackCude.transform.localPosition = Vector3.MoveTowards(attackCude.transform.localPosition, desPos, speed * Time.deltaTime);
            }

            if(Time.time - startTime > lastingTime)
            {
                QUse();
                /*Destroy(attackCude);
                activated = false;

                float remainingTime = qCdTimer.GetComponent<CooldownTimer>().cooldown - lastingTime;
                qCdTimer.GetComponent<Text>().text = remainingTime.ToString();
                qCdTimer.GetComponent<CooldownTimer>().canUse = false;*/
            }
        }
        if (back)
        {
            attackCude.transform.localPosition = Vector3.MoveTowards(attackCude.transform.localPosition, cubeManTransform.localPosition, speed * Time.deltaTime);

            if (Vector3.Distance(cubeManTransform.localPosition, attackCude.transform.localPosition) == 0f)
            {
                attackCude.GetComponent<MeshRenderer>().enabled = false;
                attackCude.GetComponent<BoxCollider>().enabled = false;
                ParticleSystem.EmissionModule em = attackCude.GetComponent<ParticleSystem>().emission;
                em.enabled = false;
                back = false;
            }
        }
	}

    public void QUse()
    {
        if (!activated && !isR)
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

            desPos = desPos - cubeManTransform.position;
            desPos = cubeManTransform.localPosition + maxDistance * desPos.normalized;
            desPos.y = cubeManTransform.position.y + 2f;

            source.PlayOneShot(qSounds[Random.Range(0, qSounds.Length)]);
            activated = true;
        }
        else if (activated)
        {
            source.PlayOneShot(qSounds[Random.Range(0, qSounds.Length)]);
            back = true;
            activated = false;
            //float remainingTime = (Time.time - startTime) / qCdTimer.GetComponent<CooldownTimer>().cooldown;
            //qCdTimer.GetComponent<Text>().text = remainingTime.ToString();
            //qCdTimer.GetComponent<RectTransform>().anchorMin = new Vector2(0f, remainingTime);
            qCdTimer.GetComponent<CooldownTimer>().startTime = startTime;
            qCdTimer.GetComponent<Image>().enabled = true;
            qCdTimer.GetComponent<CooldownTimer>().canUse = false;
        }

        if (isR)
        {
            rSkill.back = true;
            rSkill.activated = false;
            isR = false;
        }
    }
}
