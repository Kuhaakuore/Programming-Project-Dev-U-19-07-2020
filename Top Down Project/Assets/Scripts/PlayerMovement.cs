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
        PerformMove(rg2D, movement, speed);
    }

    public void PerformMove (Rigidbody2D rb, Vector2 movement, float speed)
    {
        AdjustOrientation(rb, movement);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void PerformMoveNormalized (Rigidbody2D rb, Vector2 movement, float speed)
    {
        movement.Normalize();
        PerformMove(rb, movement, speed);
    }

    public void AdjustOrientation (Rigidbody2D rb, Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            rb.rotation = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        }
    }
}