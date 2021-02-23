using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutputSlot : MonoBehaviour
{
    [SerializeField] private CraftSlot _firstCraftSlot;
    [SerializeField] private CraftSlot _secondCraftSlot;

    [SerializeField] private GameObject _elementPrefab;

    [SerializeField] private List<ElementScriptableObj> _elemList;


    public void GenerateNewElement()
    {
        if (_firstCraftSlot.IsSlotBusy && _secondCraftSlot.IsSlotBusy)
        {
            foreach (var el in _elemList)
            {
                if ((el.FirstElemForCraft.ElementName == _firstCraftSlot.CurrentElement.Name && el.SecondElemForCraft.ElementName == _secondCraftSlot.CurrentElement.Name) || (el.FirstElemForCraft.ElementName == _secondCraftSlot.CurrentElement.Name && el.SecondElemForCraft.ElementName == _firstCraftSlot.CurrentElement.Name))
                {
                    InstantiateNewElement(el);
                }
            }
        }
    }

    private void InstantiateNewElement(ElementScriptableObj el)
    {
        GameObject newobj = Instantiate(_elementPrefab, transform.position, _elementPrefab.transform.rotation, transform);
        var tempEl = newobj.GetComponent<Element>();
        newobj.GetComponent<Image>().sprite = el.Image;
        tempEl.IsInCraftSlot = false;
        tempEl.Name = el.ElementName;
        tempEl.CanvasGroupBlocksRaycasts = true;
        newobj.GetComponentInChildren<TextMeshProUGUI>().text = tempEl.Name;
    }

    private void OnEnable()
    {
        CraftSlot.OnElementDropped += GenerateNewElement;
    }

    private void OnDisable()
    {
        CraftSlot.OnElementDropped -= GenerateNewElement;
    }
}
