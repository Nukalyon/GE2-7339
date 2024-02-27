using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObjectBase
{
    public override void Interact()
    {
        Debug.Log("Parler à homard");
    }
}
