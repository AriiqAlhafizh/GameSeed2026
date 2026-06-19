using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    public PlayerInputHandler Input { get; private set; }
    public PlayerMovement Movement { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public Collider2D Collider { get; private set; }

    void Awake()
    {
        Input = GetComponent<PlayerInputHandler>();
        Movement = GetComponent<PlayerMovement>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }
}
