using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public Transform squarePerson;

    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hit1;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit1, 1000))
        {
            Vector3 adjustedPosition = new Vector3(hit1.point.x, hit1.point.y + 1, hit1.point.z);
            gameObject.transform.position = adjustedPosition;
        }
    }
}
