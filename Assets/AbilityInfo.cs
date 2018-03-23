using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject child;

    void Start() {
        child = gameObject.transform.GetChild(0).gameObject;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        child.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        child.SetActive(false);
        
    }
}