using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(this.transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
