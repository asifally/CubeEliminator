using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 20f;
    public GameObject projectilePrefab;
    public AudioClip fireSound;
    public AudioClip hitmarkerSound;

    private Rigidbody playerRb;
    private GameManager gameManager;
    public AudioSource playerAudio;
    [SerializeField] Transform firePoint;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameManager.isGameActive){
            LookAtMouse();
            Move();
            Fire();
        }
    }

    void LookAtMouse()
    {
        // ScreenPointToRay returns a Ray going from the camera through the position
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Representation of a plane in 3D space
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float enter;
 
        if (groundPlane.Raycast(cameraRay, out enter))
        {
            // Returns the position along the Ray
            Vector3 pointToLook = cameraRay.GetPoint(enter);

            // Rotate the look at the x and z position of mouse
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector3(horizontalInput, 0, verticalInput) * speed;

        // playerRb.AddForce(Vector3.up * speed * verticalInput, ForceMode.VelocityChange);
        // playerRb.AddForce(Vector3.right * speed * horizontalInput, ForceMode.VelocityChange);

        // transform.Translate(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime, Space.World);

    }

    void Fire() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAudio.PlayOneShot(fireSound);
            Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.UpdateHealth(-1);
            Destroy(other.gameObject);
        }
    }
}
