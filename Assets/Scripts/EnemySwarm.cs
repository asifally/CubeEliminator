using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwarm : Enemy
{
    [SerializeField] GameObject swarmPrefab;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            SpawnSwarm();
        }
    }

    void SpawnSwarm()
    {
        Instantiate(swarmPrefab, transform.position + Vector3.forward, transform.rotation);
        Instantiate(swarmPrefab, transform.position + Vector3.back, transform.rotation);
        Instantiate(swarmPrefab, transform.position + Vector3.left, transform.rotation);
        Instantiate(swarmPrefab, transform.position + Vector3.right, transform.rotation);
    }
}
