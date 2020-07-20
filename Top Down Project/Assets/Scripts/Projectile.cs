using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 15f), SerializeField] private float speed;
    private bool pulling = false;
    public bool collided = false;
    private Vector2 target;
    [Range(0f, 50f), SerializeField] private float areaOfEffect;
    [Range(0f, 15f), SerializeField] private float pullForce;
    public GameObject[] enemies;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target) > 0.1f && !collided)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
    public void Seek(Vector2 newTarget)
    {
        target = newTarget;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            collided = true;
            foreach (GameObject newEnemy in enemies)
            {
                while (Vector2.Distance(newEnemy.transform.position, transform.position) > 0.5f)
                {
                    newEnemy.transform.position = Vector2.MoveTowards(newEnemy.transform.position, transform.position, pullForce * Time.fixedDeltaTime);
                }
            }
        }
        else
            Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}
