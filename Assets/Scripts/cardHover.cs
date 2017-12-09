using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class cardHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer enter " + gameObject.name);
        this.
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exit " + gameObject.name);
    }
}
