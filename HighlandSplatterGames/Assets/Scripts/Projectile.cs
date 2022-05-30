using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: This script will set the velocity and direction of projectiles when a weapon is used

public class Projectile : MonoBehaviour
{
    // Declare Variables
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rigidBody;
    public float force;
    private Vector3 direction;
    private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // Get RigidBody
        rigidBody = GetComponent<Rigidbody2D>();

        // Get mouse position
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        direction = mousePosition - transform.position;
        rotation = transform.position - mousePosition;

        // Set velocity of projectile in direction of mouse
        rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float projectileRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, projectileRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
