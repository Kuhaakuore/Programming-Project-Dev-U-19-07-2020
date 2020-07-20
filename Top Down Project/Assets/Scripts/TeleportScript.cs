using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour 
{
    [Range(0f, 15f), SerializeField] private float tpRange;
    [Range(1, 5), SerializeField] private int tpCooldown;
    private Vector2 onScreenMousePosition;
    private Vector2 onWorldMousePosition;
    private bool canTeleport = true;
    public Rigidbody2D r2D;
    public void FixedUpdate()
    {
        onScreenMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        onWorldMousePosition = Camera.main.ScreenToWorldPoint(onScreenMousePosition);

        if(Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, onWorldMousePosition) < tpRange && canTeleport)
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        Debug.Log("cleiton");
        canTeleport = false;
        r2D.AddForce(onWorldMousePosition.normalized);
        yield return new WaitForSeconds(tpCooldown);
        canTeleport = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tpRange);
    }
}