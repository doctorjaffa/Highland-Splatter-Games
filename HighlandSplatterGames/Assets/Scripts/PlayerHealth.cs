using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Handle player damage and dying when told to do so by a hazard.

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    private int currentHealth = 100;

    public float hitInvincibilityMaxTime = 1;
    private float lastHitTime = 0;

    private void Awake()
    {
        //Initialise current health to be equal to the starting health when the player spawns.
        currentHealth = startingHealth;

    }

    //Action: Kill the player (Delete the player game object).
    public void Kill()
    {
        //Destroy the object this script is attached to.
        Destroy(gameObject);
    }

    //Action: Change current health by a set amount and record when the player was last hit.
    public void ChangeHealth(int changeAmount)
    {
        //Condition: Has enough time passed since the player was last damaged?
        if (Time.time >= lastHitTime + hitInvincibilityMaxTime)
        {
            currentHealth += changeAmount;

            //Action: Clamp health between 0 and starting health to avoid negative health and going above max health.
            currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

            //Condition: If current health is equal to or less than zero.
            if (currentHealth <= 0)
            {
                //Action: Call Kill() function.
                Kill();

            }

            lastHitTime = Time.time;
        }
    }

    //Getter function to return the current player health value. 
    public int GetHealth()
    {
        return currentHealth;
    }

    //Getter function to return the starting player health value. 
    public int GetMaxHealth()
    {
        return startingHealth;
    }

}