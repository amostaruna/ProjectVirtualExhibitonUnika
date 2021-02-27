using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //SerializeField Private Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    //SerializedField Private Property
    [Header("Property")]
    [SerializeField] private float moveSpeed = 5f;


    //Private Property
    private Vector2 movement;
  
  
    void Update()
    {
        InputMovement();
        InputAnimation();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    //Fungsi untuk Input Player
    private void InputMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //Fungsi untuk memberikan animasi pada player
    void InputAnimation()
    {
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            Debug.LogError("Komponen Animator Belum DiTambahkan Ke Dalam Script");
        }
    }

    //Fungsi untuk melakukan movement pada player
    void Movement()
    {
        if (rb != null)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Debug.LogError("Komponen Rigidbody Belum DiTambahkan Ke Dalam Script");
        }
    }

}
