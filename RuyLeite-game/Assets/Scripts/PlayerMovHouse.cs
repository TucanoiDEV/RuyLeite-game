using UnityEngine;

public class PlayerMovHouse : MonoBehaviour
{
    public float moveSpeed;
    public float baseSpeed;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * moveSpeed, vertical * moveSpeed));

        if((horizontal > 0 || horizontal < 0) &&  (vertical > 0 || vertical < 0))
        {
            moveSpeed = baseSpeed * 0.66f;  
        }
        else
        {
            moveSpeed = baseSpeed;
        }
    }
}
