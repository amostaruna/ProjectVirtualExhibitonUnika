﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Poster : MonoBehaviour
{
    //SerializedField Private GameObjects
    [Header("GameObjects")]
    [SerializeField] private GameObject showPoster;

    //SerializedField Private Components
    [Header("Components")]
    [SerializeField]private Animator anim;
    [SerializeField] private Text textButton;

    //CekButton digunakan untuk mengecek apakah Text("Open Poster") sudah tampil apa belum
    bool cekButton;
    //CekPoster digunakan untuk mengecek apakah Poster sudah tampil apa belum
    bool cekPoster;

    void Start()
    {
        cekPoster = false;
        cekButton = false;

        HiddenText();
        HiddenPoster();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && cekButton)
        {
            ShowPoster();
        }

        if(Input.GetKey(KeyCode.P) && cekPoster)
        {
            StartCoroutine(AnimHiddenPoster());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Jika player menyentuh poster
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Muncul Pop Up Button 
            ShowText();
            cekButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Jika player keluar dari trigger poster
        if (collision.gameObject.tag.Equals("Player"))
        {
            cekButton = false;
            //Hapus Pop Up Button
            HiddenText();
        }
    }
     
    //Fungsi untuk menampilkan poster
    private void ShowPoster()
    {
        Time.timeScale = 0;
        cekPoster = true;
        showPoster.SetActive(true);
        anim.SetBool("FadeIn", true);
    }

    //fungsi untuk menutup poster
    private void HiddenPoster()
    {
        cekPoster = false;
        Time.timeScale = 1;
        anim.SetBool("FadeIn", false);
    }

    //Fungsi untuk mengaktifkan component Text("Open Poster")
    private void ShowText()
    {
        textButton.enabled = true;
    }


    //Fungsi untuk menonaktifkan component Text("Open Poster")
    private void HiddenText()
    {
        textButton.enabled = false;
    }

    //Fungsi untuk menutup poster dg animasi
    IEnumerator AnimHiddenPoster()
    {
        anim.SetBool("FadeIn", false);
        HiddenPoster();
        yield return new WaitForSeconds(1);
        showPoster.SetActive(false);
    }
}