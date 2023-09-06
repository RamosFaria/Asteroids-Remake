using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static event Action OnTakeDamage;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float dashStrenght;
    
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(playerInput.GetDash)
        {
            rb.AddForce(transform.up * dashStrenght);
        }

        if(playerInput.GetHorizontal != 0)
        {
            rb.AddTorque( -playerInput.GetHorizontal * rotationSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var asteroid = collision.gameObject.GetComponent<Asteroid>();

        if(asteroid != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            this.gameObject.SetActive(false);
            OnTakeDamage?.Invoke();
        }
    }

}
