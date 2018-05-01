using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUseE : MonoBehaviour
{
    public bool activated;
    public float speed;
    public float maxDistance;
    public Vector3 desPos;
    public Vector3 startPos;
    public Vector3 lastPos;
    public Transform cubeManTransform;
    public ParticleSystem trailEffect;

    // Use this for initialization
    void Start()
    {
        activated = false;
        ParticleSystem.EmissionModule em = trailEffect.emission;
        em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            float diff = Vector3.Distance(startPos, cubeManTransform.localPosition);

            cubeManTransform.localPosition = Vector3.MoveTowards(cubeManTransform.localPosition, desPos, speed * Time.deltaTime);

            float diff2 = Vector3.Distance(lastPos, cubeManTransform.localPosition);

            if (Vector3.Equals(cubeManTransform.localPosition, desPos) || diff >= maxDistance || diff2 < 0.1f)
            {
                activated = false;
                ParticleSystem.EmissionModule em = trailEffect.emission;
                em.enabled = false;
                cubeManTransform.gameObject.tag = "square";
            }

            lastPos = cubeManTransform.localPosition;
        }
        
    }

    public void EUse()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            desPos = new Vector3(hit.point.x, cubeManTransform.position.y, hit.point.z);
        }

        desPos = desPos - cubeManTransform.position;
        desPos = cubeManTransform.localPosition + maxDistance * desPos.normalized;
        desPos.y = cubeManTransform.position.y;

        startPos = cubeManTransform.localPosition;
        activated = true;
        ParticleSystem.EmissionModule em= trailEffect.emission;
        em.enabled = true;
        cubeManTransform.gameObject.tag = "playerAttack";
    }
}
