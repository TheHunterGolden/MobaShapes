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
    public Transform cubeManTransform;

    // Use this for initialization
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            float diff = Vector3.Distance(startPos, cubeManTransform.localPosition);

            cubeManTransform.localPosition = Vector3.MoveTowards(cubeManTransform.localPosition, desPos, speed * Time.deltaTime);
            
            if (Vector3.Equals(cubeManTransform.localPosition, desPos) || diff >= maxDistance)
            {
                activated = false;
            }
        }
        
    }

    public void EUse()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            desPos = new Vector3(hit.point.x, cubeManTransform.position.y, hit.point.z);
        }

        startPos = cubeManTransform.localPosition;
        activated = true;
    }
}
