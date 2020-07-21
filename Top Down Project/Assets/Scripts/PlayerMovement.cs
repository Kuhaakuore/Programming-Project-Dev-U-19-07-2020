using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    [Range(0f, 15f), SerializeField] private float speed;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    [SerializeField] private Rigidbody2D rg2D;

    public void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        verticalMove = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(rg2D, movement, speed);
    }

    public void Move (Rigidbody2D rb, Vector2 movement, float speed)
    {
        movement.Normalize();
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}