using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputSystem_Actions action;
    Vector2 moveInput;

    void Awake()
    {
        action = new InputSystem_Actions();
    }

    void OnEnable()
    {
        action.Player.Move.performed += Move;
        action.Enable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Debug.Log(moveInput);
    }

    void OnDisable()
    {
        action.Player.Move.performed -= Move;
        action.Disable();
    }
}
