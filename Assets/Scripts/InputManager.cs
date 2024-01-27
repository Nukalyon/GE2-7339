using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    PlayerControls controls;

    public static Vector2 mouvementInput;
    public static Vector2 tournerInput;

    public static bool isAimingInput = false;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
    }

    private void OnEnable()
    {
        controls.Player.Mouvement.performed += Move;
        controls.Player.Mouvement.canceled += Move;
        
        controls.Player.Tourner.performed += Tourner;
        controls.Player.Tourner.canceled += Tourner;

        controls.Player.Viser.performed += ctx => isAimingInput = true;
        controls.Player.Viser.canceled += ctx => isAimingInput = false;
    }

    private void OnDisable()
    {
        controls.Player.Mouvement.performed -= Move;
        controls.Player.Tourner.performed -= Tourner;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        mouvementInput = ctx.ReadValue<Vector2>();
    }

    private void Tourner(InputAction.CallbackContext ctx)
    {
        tournerInput = ctx.ReadValue<Vector2>();
    }


}
