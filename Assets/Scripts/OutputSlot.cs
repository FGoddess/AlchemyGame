using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputSlot : MonoBehaviour
{
    [SerializeField] private CraftSlot _firstCraftSlot; 
    [SerializeField] private CraftSlot _secondCraftSlot;
    
    public void GenerateNewElement()
    {
        if(_firstCraftSlot.IsSlotBusy && _secondCraftSlot.IsSlotBusy)
        {
            //some logic
        }
    }
}
