using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //Contains the slider component attached to object.
    //Slider = variable is in the form of a Slider component.
    Slider healthBar;

    //PlayerHealth component that can be give info about the player's health.
    PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        // Get a Slider component from the game object this script is attached to
        // Store the Slider component in our healthSlider variable
        healthBar = GetComponent<Slider>();

        // Search the scene for the object with PlayerHealth script attached
        // Store the PlayerHealth component from that object in our player variable
        player = FindObjectOfType<PlayerHealth>();
    }

    // Built in Unity function
    // Update is called once per frame
    void Update()
    {
        // Get the current and max health values from the player
        // Store these values in float variables
        // We use float because we need decimal points for the slider 
        // (not whole numbers aka integers)
        float currentHealth = player.GetHealth();
        float maxHealth = player.GetMaxHealth();

        // The slider value should be something between 0 and 1, with 1 being full
        // We want the fraction of fill for the slider
        // So we divide the current health by the max health
        healthBar.value = currentHealth / maxHealth;
    }
}
