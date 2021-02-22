using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputSlot : MonoBehaviour
{
    [SerializeField] private CraftSlot _firstCraftSlot;
    [SerializeField] private CraftSlot _secondCraftSlot;

    [SerializeField] private GameObject _elementPrefab;

    [SerializeField] private ElementScriptableObj _elem;


    public void GenerateNewElement()
    {
        if(_firstCraftSlot.IsSlotBusy && _secondCraftSlot.IsSlotBusy)
        {
            Debug.Log("Зашло");
            GameObject newobj = Instantiate(_elementPrefab, transform.position, _elementPrefab.transform.rotation, transform);
            newobj.GetComponent<Element>().IsInCraftSlot = false;
            newobj.GetComponent<Image>().sprite = _elem.image;
        }
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
