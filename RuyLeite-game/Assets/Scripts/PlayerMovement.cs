using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
