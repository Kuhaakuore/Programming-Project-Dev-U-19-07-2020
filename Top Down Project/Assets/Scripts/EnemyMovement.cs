using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    [Range(0f, 15f), SerializeField] private float movementSpeed;
    public Rigidbody2D rg2D;
    private Rigidbody2D myRg;
    bool pulled = false;

    private void Start()
    {
        myRg = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PursuitPlayer();
    }

    public void PursuitPlayer()
    {
        //Calcula a posição do player
        Vector2 direction = rg2D.position - myRg.position;
        direction.Normalize();

        //Calcula a velocidade do inimigo
        Vector2 velocity = direction * movementSpeed;

        //Vai até o player se estiver distante do mesmo
        if(Vector2.Distance(rg2D.position, myRg.position) >= 0.5f)
        {
            myRg.velocity = new Vector2(velocity.x, velocity.y);
        }
        //Para quando estiver a uma certa distância do player
        else
        {
            myRg.velocity = new Vector2(0, 0);
        }
    }
}