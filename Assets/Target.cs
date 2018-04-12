using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public Transform squarePerson;
    public RectTransform rt;
    public Vector3 position;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hit1;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit1, 1000))
        {
            Vector3 adjustedPosition = new Vector3(hit1.point.x, squarePerson.position.y, hit1.point.z);
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(adjustedPosition);
            rt.localPosition = new Vector3(screenPoint.x - 390, screenPoint.y - 200, 0);
        }

        position = Input.mousePosition;
    }
}
