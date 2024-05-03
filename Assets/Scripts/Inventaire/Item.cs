using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Inventaire/Creer un nouveau item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable = false;
}


[CreateAssetMenu(fileName = "new consumable", menuName = "Inventaire/Creer un nouveau item consumable")]
public class ConsumableItem : Item
{
    public void Consume()
    {
        Debug.Log("Consume Item");
    }
}