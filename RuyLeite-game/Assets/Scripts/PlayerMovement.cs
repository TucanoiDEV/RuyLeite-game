using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (horizontalInput * moveSpeed, 0));

        animator.SetBool("walk", horizontalInput != 0);
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
