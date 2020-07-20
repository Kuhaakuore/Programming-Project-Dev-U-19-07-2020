using UnityEngine;
using System.Collections;

public class PlayerRangedAttacks : MonoBehaviour 
{
    [SerializeField]  private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [Range(0f, 5f), SerializeField] private float shotCooldown;
    private bool canShoot = true;
    private Vector2 onScreenMousePosition;
    private Vector2 onWorldMousePosition;
    public void FixedUpdate()
    {
        onScreenMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        onWorldMousePosition = Camera.main.ScreenToWorldPoint(onScreenMousePosition);
        if(Input.GetMouseButtonDown(1))
        {
            StartCoroutine(FireProjectile());
        }
    }

    IEnumerator FireProjectile()
    {
        canShoot = false;
        
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile p = projectile.GetComponent<Projectile>();

        if (p != null)
            p.Seek(onWorldMousePosition);

        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }
}