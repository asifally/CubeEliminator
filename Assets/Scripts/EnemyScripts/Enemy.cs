using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 8.0f;

    protected GameObject player;
    protected GameManager gameManagerScript;
    protected Rigidbody enemyRb;
    protected int dropChance = 6;
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            MoveTowardsPlayer();
        }   
    }

    public virtual void MoveTowardsPlayer()
    {
        transform.LookAt(player.gameObject.transform);

        transform.position += transform.forward * speed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0);
    }

    public void Explode()
    {
        ParticleSystem explosionEffect = Instantiate(explosionParticles, gameObject.transform.position, gameObject.transform.rotation);
        explosionEffect.transform.position = gameObject.transform.position;
        explosionEffect.Play();
    }

    public virtual void PowerupDropChance()
    {
        int num = Random.Range(0, dropChance * gameManagerScript.powerupDropMultiplier);

        if (num == 1)
        {
            gameManagerScript.SpawnHealthPowerup(gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
