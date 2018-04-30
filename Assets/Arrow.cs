using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float distance;
    public float speed;
    public float top;
    public float down;

    private void Start()
    {
        top = transform.localPosition.y + distance;
        down = transform.localPosition.y - distance;
    }

    // Update is called once per frame
    private void Update () {
        if (transform.localPosition.y > top)
        {
            Vector3 temp = new Vector3(0f, top, 0f);
            transform.localPosition = temp;
            speed = -speed;
        }else if (transform.localPosition.y < down)
        {
            Vector3 temp = new Vector3(0f, down, 0f);
            transform.localPosition = temp;
            speed = -speed;
        }

        transform.Translate(0f, speed * Time.deltaTime, 0f);
        transform.Rotate(0f, Mathf.Abs(speed) * Time.deltaTime * 20f, 0f);
        
	}
}
