using UnityEngine;
using UnityEngine.EventSystems;

public class CraftSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool _isSlotBusy = false;
    [SerializeField] private Element _element;

    public bool IsSlotBusy
    {
        get { return _isSlotBusy; }
        set { _isSlotBusy = value; }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !_isSlotBusy)
        {
            eventData.pointerDrag.transform.SetParent(this.transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            _isSlotBusy = true;
            _element = eventData.pointerDrag.GetComponent<Element>();
            _element.IsInCraftSlot = true;
        }
    }
}
