using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    
    public Dictionary<Item, int> inventaireActuel = new Dictionary<Item, int>();
    public static event Action<Item> OnInventaireModifier;

    public Item[] itemsDeDepart;
    
    public static InventoryController singleton;
    
    void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        foreach(Item item in itemsDeDepart)
        {
            AddItem(item);
        }
    }


    public void AddItem(Item item, int amount = 1)
    {
        if (inventaireActuel.TryAdd(item, amount))
        {
            inventaireActuel[item] += amount;
            OnInventaireModifier?.Invoke(item);
        }
    }
    
    public void RemoveItem(Item item, int amount = 1)
    {
        if (!inventaireActuel.ContainsKey(item)) return;
        
        inventaireActuel[item] -= amount;
        
        if (inventaireActuel[item] <= 0)
        {
            inventaireActuel.Remove(item);
        }
        
        OnInventaireModifier?.Invoke(item);
    }
    
}
