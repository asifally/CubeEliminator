using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerScript.playerAudio.PlayOneShot(playerScript.hitmarkerSound, 1);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(1);
        }
    }
}
