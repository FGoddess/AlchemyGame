using UnityEngine;
using UnityEngine.EventSystems;

public class CraftSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool _isSlotBusy = false;
    [SerializeField] private Element _element;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !_isSlotBusy)
        {
            eventData.pointerDrag.transform.SetParent(this.transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            _isSlotBusy = true;
            _element = eventData.pointerDrag.GetComponent<Element>();
            _element._isInCraftSlot = true;
        }
    }

    public void SetBool()
    {
        _isSlotBusy = false;
    }
}
