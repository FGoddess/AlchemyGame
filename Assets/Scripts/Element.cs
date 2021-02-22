using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Transform _newParent;
    [SerializeField] private Transform _defaultParent;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] public bool _isInCraftSlot = false;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_isInCraftSlot)
        {
            _isInCraftSlot = false;
            GetComponentInParent<CraftSlot>().SetBool();
        }
        _canvasGroup.blocksRaycasts = false;
        transform.SetParent(_newParent);
        SetAnchorToMiddleCenter();
    }

    private void SetAnchorToMiddleCenter()
    {
        _rectTransform.anchorMax = new Vector2(.5f, .5f);
        _rectTransform.anchorMin = new Vector2(.5f, .5f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //_rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;

        if(!_isInCraftSlot)
        {
            transform.SetParent(_defaultParent);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("On Pointer Down");
    }
}
