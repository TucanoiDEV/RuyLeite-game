using UnityEngine;

public class PlayerMovHouse : MonoBehaviour
{
    public float moveSpeed;
    public float baseSpeed;
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
        float verticalInput = Input.GetAxisRaw("Vertical");

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed));

        if((horizontalInput > 0 || horizontalInput < 0) &&  (verticalInput > 0 || verticalInput < 0))
        {
            moveSpeed = baseSpeed * 0.66f;  
        }
        else
        {
            moveSpeed = baseSpeed;
        }
        animator.SetBool("walk", horizontalInput != 0 || verticalInput != 0);
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0 || verticalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
