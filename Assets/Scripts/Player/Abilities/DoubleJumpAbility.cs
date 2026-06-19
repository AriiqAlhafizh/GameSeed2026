using UnityEngine;

public class DoubleJumpAbility : Ability
{
    public int maxJumps = 2;
    public int jumps = 0;

    private void Start()
    {
        context.Input.JumpPressed += Jump;
        context.Movement.OnLand += ResetJumps;
        context.Movement.OnJump += IncreaseJumps;
    }

    private void ResetJumps()
    {
        jumps = 0;
    }

    private void IncreaseJumps()
    {
        if (jumps < maxJumps)
        {
            jumps++;
        }
    }

    private void Jump()
    {
        if (jumps < maxJumps)
        {
            context.Movement.ResetCoyoteTime();
            context.Movement.JumpPressed(); // BUG: Double Jump ability trigger dua kali walau cuma sekali tekan
        }
    }
}
