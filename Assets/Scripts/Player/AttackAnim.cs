using UnityEngine;

public class AttackAnim : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
        }
    }

    public void TriggerAttack()
    { 
        animator.SetTrigger("Attack");
    }
}
