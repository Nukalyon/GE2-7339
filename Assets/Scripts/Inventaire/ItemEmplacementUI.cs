using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemEmplacementUI : MonoBehaviour
{
    [ReadOnly] public Item monItem;
    public Image image;
    public TMP_Text text;

    public void UpdateUI(Item item)
    {
        monItem = item;
        image.sprite = item.itemIcon;

        if (item.isStackable)
        {
            text.text = InventoryController.singleton.inventaireActuel[item].ToString();
        }
        else
        {
            text.text = "";
        }
        
    }
}
