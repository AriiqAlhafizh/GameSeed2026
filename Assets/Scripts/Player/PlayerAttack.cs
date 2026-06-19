using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public enum AttackDirection
{
    Up,
    Right,
    Down,
    Left
}

public enum AttackType
{
    Basic,
    Pogo,
    Upslash
}
public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    // NOTE: attack anims are subject to change
    public List<AttackAnim> attackAnims;
    public PlayerInputHandler input;

    [Header("Settings")]
    public float attackCooldown = 0.5f; // Cooldown in seconds

    [Header("Debug")]
    [SerializeField] private AttackDirection atkDir = AttackDirection.Right;
    [SerializeField] private AttackDirection lastXDir = AttackDirection.Right;
    [SerializeField] private float lastAttackTime = -Mathf.Infinity;

    // Events
    public delegate void PogoEvent();
    public event PogoEvent OnPogo;

    private void Start()
    {
        input = GetComponent<PlayerInputHandler>();
        input.AttackPressed += Attack;
    }
    private void Update()
    {
        MoveAttackDirection();
    }
    public void MoveAttackDirection()
    {
        // Update lastXDir if X input is non-zero
        if (input.MovementVector.x < 0)
            lastXDir = AttackDirection.Left;
        else if (input.MovementVector.x > 0)
            lastXDir = AttackDirection.Right;

        // Set atkDir based on Y input.MovementVector, otherwise use lastXDir
        if (input.MovementVector.y > 0)
            atkDir = AttackDirection.Up;
        else if (input.MovementVector.y < 0)
            atkDir = AttackDirection.Down;
        else
            atkDir = lastXDir;
    }
    public void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            StartAttack(atkDir);
            lastAttackTime = Time.time;
        }
    }
    private void StartAttack(AttackDirection dir)
    {
        if (dir == AttackDirection.Down)
            OnPogo?.Invoke();
        attackAnims[(int)dir].TriggerAttack();
    }
}
