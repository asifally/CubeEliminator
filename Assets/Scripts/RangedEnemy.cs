using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    
    [SerializeField] float fireDelay = 0.5f;
    [SerializeField] GameObject enemyProjectilePrefab;
    [SerializeField] Transform firePoint;
    private float withinPlayerRange = 15.0f;
    private bool canShoot = true;

    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            transform.LookAt(player.gameObject.transform);
            if (GetDistanceFromPlayer() > withinPlayerRange)
            {
                MoveTowardsPlayer();
            }
            else if (GetDistanceFromPlayer() < withinPlayerRange && canShoot)
            {
                StartCoroutine(ShootAtPlayer());
            }
        }
    }

    public override void MoveTowardsPlayer()
    {
        transform.LookAt(player.gameObject.transform);

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    float GetDistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Debug.Log(distanceFromPlayer);
        return distanceFromPlayer;
    }

    private IEnumerator ShootAtPlayer()
    {
        Instantiate(enemyProjectilePrefab, firePoint.position, transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(fireDelay);
        canShoot = true;
    }
}
