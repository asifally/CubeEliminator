using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 40.0f;
    protected GameManager gameManager;
    protected PlayerController playerScript;
    private float range = 65.0f;

    private void Start() {
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
