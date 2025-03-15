using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private PlayerStats stats;
    private PlayerInputHandler inputHandler;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = inputHandler.MoveInput * stats.moveSpeed;
        rb.velocity = movement;
    }
}