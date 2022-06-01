using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Rigidbody2D physicsBody = null;
    public Animator animator;

	

    public float moveSpeed = 40f;
    float horizontalMove = 0f;
    
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        physicsBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       
        //Goes from -speed to +speed
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        //Inputs dictated by Input Manager in Unity
        if (Input.GetButtonDown("Jump"))
		{
            jump = true;
            animator.SetBool("isJumping", true);
		}

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
		{
            crouch = false;
		}
             
    }

	void FixedUpdate()
	{
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
	}
	

    public void OnLanding()
	{
        jump = false;
        animator.SetBool("isJumping", false);
	}

    public void OnCrouching(bool isCrouching)
	{
        animator.SetBool("isCrouching" , isCrouching);
	}
    
    
}
