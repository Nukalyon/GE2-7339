using UnityEngine;

public class Coffre : InteractableObjectBase
{
    public override void Interact()
    {
        //Do Something
        OpenChest();
    }

    public void OpenChest()
    {
        Debug.Log("Ouverture du coffre");
    }
}
