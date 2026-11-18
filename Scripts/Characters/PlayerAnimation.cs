using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    private float x;
    private bool isJumping;
    private bool isFalling;
    private Animator animator;
    private Rigidbody2D rb;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetFloat("VerticalSpeed", rb.velocity.y);
        isJumping = !playerMovement.IsGrounded && rb.velocity.y > 0.1f;
        isFalling = !playerMovement.IsGrounded && rb.velocity.y <= -0.1f;
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

}