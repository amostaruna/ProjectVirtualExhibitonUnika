﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueTrigger : MonoBehaviour
{
    [Header("GameObjects")] [SerializeField]
    public GameObject dialogueBox;

    public DialogueTrigger DT;
    [SerializeField] private GameObject emoticon;

    [Header("Components")] [SerializeField]
    private Text notificationText;

    public bool dialogueOpenedCheck;
    bool dialogueCheck;
    bool buttonCheck;

    private float timer = 0;
    private bool emoticonShow;

    private void Awake()
    {
        if (dialogueBox == null)
        {
            Debug.Log("Dialogue box for character " + gameObject.name + " not yet included");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        emoticon.SetActive(false);
        emoticonShow = false;
        dialogueCheck = false;
        HideNotification();
        HideDialogueBox();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && buttonCheck && dialogueOpenedCheck == false)
        {
            emoticon.SetActive(false);
            ShowDialogueBox();
        }

        if (Input.GetKey(KeyCode.P) && dialogueCheck)
        {
            emoticon.SetActive(false);
            HideDialogueBox();
        }

        if (!dialogueOpenedCheck)
        {
            timer += Time.deltaTime;

            if (timer > 7 && !emoticonShow && !dialogueOpenedCheck)
            {
                emoticon.SetActive(true);
                emoticonShow = true;
                timer = 0;
            }else if (timer > 5 && emoticonShow)
            {
                emoticon.SetActive(false);
                emoticonShow = false;
                timer = 0;
            }
        }
        
    }

    private void HideNotification() //menonaktifkan notifikasi 
    {
        notificationText.enabled = false;
    }

    private void ShowNotification() //mengaktifkan notifikasi
    {
        notificationText.enabled = true;
    }

    private void HideDialogueBox() //menyembunyikan dialoguebox
    {
        dialogueCheck = false;
        dialogueOpenedCheck = false;
        dialogueBox.SetActive(false);
    }

    private void ShowDialogueBox() //menampilkan dialoguebox
    {
        HideNotification();
        dialogueBox.SetActive(true);
        DT.triggerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Jika player menyentuh NPC
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Muncul Pop Up notifikasi  
            buttonCheck = true;
            ShowNotification();
            emoticon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Jika player keluar dari trigger NPC
        if (collision.gameObject.tag.Equals("Player"))
        {
            //menonaktifkan notifikasi
            buttonCheck = false;
            HideNotification();
        }
    }
}