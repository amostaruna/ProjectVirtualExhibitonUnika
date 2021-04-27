using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //SerializeField Private Components
    [Header("Components")] [SerializeField]
    private Rigidbody2D rb;

    [SerializeField] private Animator Char1Animator;
    [SerializeField] private Animator Char2Animator;
    [SerializeField] private Animator Char3Animator;
    [SerializeField] private Animator Char4Animator;

    //SerializedField Private Property
    [Header("Property")] [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private GameObject MainChar1;
    [SerializeField] private GameObject MainChar2;
    [SerializeField] private GameObject MainChar3;
    [SerializeField] private GameObject MainChar4;

    //Joystick
    [SerializeField] private Joystick _joystick;

    //Private Property
    private Vector2 movement;

    private void Start()
    {
        Data.coin = PlayerPrefs.GetInt("Coin", 0);
        MainChar1 = GameObject.Find("MainChar1");
        MainChar2 = GameObject.Find("MainChar2");
        MainChar3 = GameObject.Find("MainChar3");
        MainChar4 = GameObject.Find("MainChar4");
        if (Data.CharNum == 1)
        {
            MainChar2.SetActive(false);
            MainChar3.SetActive(false);
            MainChar4.SetActive(false);
        }
        else if (Data.CharNum == 2)
        {
            MainChar1.SetActive(false);
            MainChar3.SetActive(false);
            MainChar4.SetActive(false);
        }
        else if (Data.CharNum == 3)
        {
            MainChar1.SetActive(false);
            MainChar2.SetActive(false);
            MainChar4.SetActive(false);
        }
        else if (Data.CharNum == 4)
        {
            MainChar1.SetActive(false);
            MainChar2.SetActive(false);
            MainChar3.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            transform.position = new Vector2(
                //PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "X", -23f),
                //PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Y", 2f));
                //debug
                PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "X", -20f),
                PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "Y", -3f));
        }
    }

    void Update()
    {
        Debug.Log(Data.coin);
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
        
       // movement.x = _joystick.Horizontal;    //hapus // untuk menge enable joystick
        // movement.y = _joystick.Vertical;
    }

    //Fungsi untuk memberikan animasi pada player
    void InputAnimation()
    {
        if (Data.CharNum == 1)
        {
            Char1Animator.SetFloat("Horizontal", movement.x);
            Char1Animator.SetFloat("Vertical", movement.y);
            Char1Animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else if (Data.CharNum == 2)
        {
            Char2Animator.SetFloat("Horizontal", movement.x);
            Char2Animator.SetFloat("Vertical", movement.y);
            Char2Animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else if (Data.CharNum == 3)
        {
            Char3Animator.SetFloat("Horizontal", movement.x);
            Char3Animator.SetFloat("Vertical", movement.y);
            Char3Animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else if (Data.CharNum == 4)
        {
            Char4Animator.SetFloat("Horizontal", movement.x);
            Char4Animator.SetFloat("Vertical", movement.y);
            Char4Animator.SetFloat("Speed", movement.sqrMagnitude);
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