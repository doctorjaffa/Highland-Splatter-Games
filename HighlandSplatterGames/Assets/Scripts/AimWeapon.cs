using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PURPOSE: This script will allow the player to aim and fire projectiles in direction of mouse pointer



public class AimWeapon : MonoBehaviour
{
    // Declare Variables
    private Vector3 mousePosition;
    private Vector3 rotation;
    float rotationZ;

    public GameObject Projectile;
    public Transform weaponTransform;

    public bool canFire;
    public float timer;
    public float fireResetTime = 1;

    public int turns = 5;
    public Text turnCounter;

    private Camera mainCamera;

    



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        rotation = mousePosition - transform.position;

        // Get calculate angle and convert to degrees
        rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        // Allow player to use weapon by left clicking
        if (Input.GetMouseButton(0) && canFire && turns > 0)
        {
            // Create a copy of the weapon when it is fired
            Instantiate(Projectile, weaponTransform.position, Quaternion.identity);

            // Decrease turns by 1
           // turns--;

            // Set canFire to false
            canFire = false;
        }

        // Allow player to use weapon again after time has passed
        if (!canFire)
        {
            // Start timer
            timer += Time.deltaTime;

            // Check if enough time has passed
            if (timer > fireResetTime)
            {
                // Set canFire to true
                canFire = true;

                // Reset timer
                timer = 0;
            }
        }

        turnCounter.text = turns.ToString();

        
    }
}
