using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private ItemEmplacementUI[] emplacements;

    private void UpdateUI(Item item)
    {
        if (item.isStackable)
        {
            foreach (ItemEmplacementUI e in emplacements)
            {
                if (e.monItem == item)
                {
                    e.UpdateUI(item);
                    return;
                }
            }
        }
        
        foreach (ItemEmplacementUI e in emplacements)
        {
            if (e.monItem != null)
            {
                e.UpdateUI(item);
                continue;
            }

            return;
        }
        
    }

    private void OnEnable()
    {
        InventoryController.OnInventaireModifier += UpdateUI;
    }
    
    private void OnDisable()
    {
        InventoryController.OnInventaireModifier -= UpdateUI;
    }
}
