using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    PlayerControls controls;

    public static Vector2 mouvementInput;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
    }

    private void OnEnable()
    {
        controls.Player.Mouvement.performed += Move;
    }

    private void OnDisable()
    {
        controls.Player.Mouvement.performed -= Move;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        mouvementInput = ctx.ReadValue<Vector2>();
        Debug.Log(mouvementInput);
    }

}
