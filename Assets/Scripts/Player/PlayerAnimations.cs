using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    public RuntimeAnimatorController defaultController;
    public AnimatorOverrideController overrideController;

    private int currentStateHash;
    [SerializeField] private bool isAttacking;

    public readonly int PlayerIdle = Animator.StringToHash("Idle");
    public readonly int PlayerWalk = Animator.StringToHash("Walk");
    public readonly int PlayerJump = Animator.StringToHash("Jump");
    public readonly int PlayerOnAir = Animator.StringToHash("OnAir");
    public readonly int PlayerLanding = Animator.StringToHash("Landing");
    public readonly int PlayerAttack = Animator.StringToHash("Attack_1");

    public readonly int IsWalkingHash = Animator.StringToHash("isWalking");
    public readonly int IsFallingHash = Animator.StringToHash("isFalling");

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        defaultController = animator.runtimeAnimatorController;
    }

    public void OverrideAnimation()
    {
        animator.runtimeAnimatorController = overrideController;
    }

    public void ResetAnimation()
    {
        animator.runtimeAnimatorController = defaultController;
    }
    public void ChangeAnimationState(int newStateHash)
    {
        // Prevent restarting the animation if it is already playing
        if (currentStateHash == newStateHash) return;

        // Play the animation instantly without transitions
        animator.Play(newStateHash);
        currentStateHash = newStateHash;
    }

    public void SetTrigger(int triggerHash)
    {
        if (!isAttacking)
            animator.SetTrigger(triggerHash);
    }

    public void SetBool(int boolHash, bool value)
    {
        if (!isAttacking)
            animator.SetBool(boolHash, value);
    }

    public void StartIdle()
    {
        if (!isAttacking)
        {
            ChangeAnimationState(PlayerIdle);
        }
    }

    public void StartWalk()
    {
        if (!isAttacking)
        {
            ChangeAnimationState(PlayerWalk);
        }
    }

    public void StartJump()
    {
        if (!isAttacking)
            ChangeAnimationState(PlayerJump);
    }

    public void StartOnAir()
    {
        if (!isAttacking)
            ChangeAnimationState(PlayerOnAir);
    }

    public void StartLanding()
    {
        if (!isAttacking)
            ChangeAnimationState(PlayerLanding);
    }

    public void StartAttack()
    {
        ChangeAnimationState(PlayerAttack);
    }

    public void SetIsAttacking(bool value)
    {
        isAttacking = value;
    }
}