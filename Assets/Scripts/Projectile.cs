using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 40.0f;
    
    private float range = 65.0f;

    private Rigidbody projectileRb;
    private GameManager gameManager;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // projectileRb.velocity = transform.forward * speed;
        transform.position += transform.forward * speed * Time.deltaTime;
        CleanUp();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerScript.playerAudio.PlayOneShot(playerScript.hitmarkerSound, 1);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager.UpdateScore(1);
        }
    }

    void CleanUp()
    {
        if (transform.position.x > range)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -range)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > range)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -range)
        {
            Destroy(gameObject);
        }
    }
}
