using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : InteractableObjectBase
{
    public void Activate()
    {
        // Faire quelque chose
        transform.Rotate(0, 0,90 );
    }

    public override void Interact()
    {
        Activate();
    }
}
