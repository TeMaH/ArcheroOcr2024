using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    InputSystem_Actions action;
    Vector2 moveInput;
    public Vector2 MoveInput => moveInput;
    public Action<Vector2> OnMove;
    
    void Awake()
    {
        action = new InputSystem_Actions();
    }

    void OnEnable()
    {
        action.Player.Move.performed += OnMovePerformed;
        action.Player.Move.canceled += OnMoveCanceled;
        action.Enable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        OnMove?.Invoke(moveInput);
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
        OnMove?.Invoke(moveInput);
    }

    void OnDisable()
    {
        action.Player.Move.performed -= OnMovePerformed;
        action.Player.Move.canceled -= OnMoveCanceled;
        action.Disable();
    }
}
