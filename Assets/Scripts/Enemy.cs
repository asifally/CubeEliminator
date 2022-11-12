using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 8.0f;

    protected GameObject player;
    protected GameManager gameManagerScript;
    protected Rigidbody enemyRb;

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
}
