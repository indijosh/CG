using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dropZone : MonoBehaviour, IDropHandler {

	public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to " + gameObject.name);

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnDrop to " + gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped onto " + gameObject.name);
    }
}
