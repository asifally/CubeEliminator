using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{

    [SerializeField] ParticleSystem enemyExplosion;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerScript.playerAudio.PlayOneShot(playerScript.hitmarkerSound, 1);
            other.gameObject.GetComponent<Enemy>().Explode();
            other.gameObject.GetComponent<Enemy>().PowerupDropChance();
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(1);
        }
    }
}
