using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: This script will kill the player when they touch the object this script is attached to.

public class Hazard : MonoBehaviour
{

    //Amount of damage this hazard deals.
    [Header("Positive number for damage the hazard should deal.")]

    [Tooltip("Positive number for damage the hazard should deal.")]
    public int hazardDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Get the health component from the object. 
        PlayerHealth healthScript = collision.gameObject.GetComponent<PlayerHealth>();

        //Condition: When the hazard object collides with the player.
        if (healthScript)
        {
            healthScript.ChangeHealth(-hazardDamage);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}