using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cameraNormal;
    [SerializeField] private CinemachineVirtualCamera cameraViser;

    // Update is called once per frame
    void Update()
    {
        if(InputManager.isAimingInput == true)
        {
            cameraNormal.Priority = 0;
            cameraViser.Priority = 1;
        }
        else
        {
            cameraNormal.Priority = 1;
            cameraViser.Priority = 0;
        }
    }
}
