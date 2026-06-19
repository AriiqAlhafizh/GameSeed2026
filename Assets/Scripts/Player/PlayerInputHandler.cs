using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Values")]
    public Vector2 MovementVector;

    [Header("References")]
    [SerializeField] private PlayerInput playerInput;

    public event Action JumpPressed;
    public event Action JumpReleased;

    public event Action DashPressed;
    public event Action AttackPressed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Player");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementVector = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            JumpPressed?.Invoke();

        if (context.canceled)
            JumpReleased?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
            DashPressed?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
            AttackPressed?.Invoke();
    }
}