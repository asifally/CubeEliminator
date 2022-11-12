using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerScript.playerAudio.PlayOneShot(playerScript.damageSound);
            gameManager.UpdateHealth(-1);
        }
    }
}
