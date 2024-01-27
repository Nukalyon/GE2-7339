using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourner : MonoBehaviour
{

    private float xRotation = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * InputManager.tournerInput.x);

        xRotation -= InputManager.tournerInput.y;
        xRotation = Mathf.Clamp(xRotation, -60, 60);

        transform.localEulerAngles = new Vector3(xRotation, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);


    }
}
