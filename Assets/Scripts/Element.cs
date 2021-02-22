using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Transform _defaultParent;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _canvasGroup;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        transform.SetParent(_defaultParent);
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }
}
