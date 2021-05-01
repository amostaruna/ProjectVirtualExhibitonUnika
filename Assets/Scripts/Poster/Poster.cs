using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poster : MonoBehaviour
{
    //SerializedField Private GameObjects
    [Header("GameObjects")]
    [SerializeField] private GameObject posterFull;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject btnInteract;

    //SerializedField Private Components
    [Header("Components")]
    [SerializeField]private Animator anim;
    [SerializeField] private Text textButton;
    //mengecek apakah koin sudah diambil. 0 untuk blom, 1 untuk sudah
    int coinAlreadyPicked;

    //CekButton digunakan untuk mengecek apakah Text("Open Poster") sudah tampil apa belum
    bool cekButton;
    //CekPoster digunakan untuk mengecek apakah Poster sudah tampil apa belum
    bool cekPoster;

    //game objek,*khusus video seminar*
    [Header("Khusus Video Seminar")]
    [SerializeField] private GameObject NoMainChar;
    [SerializeField] private GameObject MainChar1;
    [SerializeField] private GameObject MainChar2;
    [SerializeField] private GameObject MainChar3;
    [SerializeField] private GameObject MainChar4;
    [SerializeField] public GameObject SeminarAAE;
    [SerializeField] public GameObject SeminarBOS;
    [SerializeField] public GameObject PleaseSitSign;
    [SerializeField] public GameObject Player;
    [SerializeField] public GameObject PlayerSitCam;
    private void Awake()
    {
        if(posterFull == null)
        {
            Debug.LogError("Poster Pada GameObject Dengan Nama" + gameObject.name + " Belum di tambahkan");
        }
    }

    void Start()
    {
        cekPoster = false;
        cekButton = false;
        HiddenText();
        HiddenPoster();
       
        coin.SetActive(false);
        //PlayerPrefs.SetInt(gameObject.name, 0); //reset coin data, hapus "//", run game kemudian exit// tambahkan kem
        //Data.coin = 0;
        coinAlreadyPicked =  PlayerPrefs.GetInt(gameObject.name, 0);

        if (btnInteract != null)
        {
            btnInteract.SetActive(false);
        }

        //OBJEK KHUSUS VIDEO SEMINAR
        SeminarAAE.SetActive(false);
        SeminarBOS.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(gameObject.name +" key "+coinAlreadyPicked);
        if (Input.GetKey(KeyCode.E) && cekButton)
        {
            PlayerPrefs.SetInt("GetCoin", 1);
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
            btnInteract.SetActive(true);
            cekButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Jika player keluar dari trigger poster
        if (collision.gameObject.tag.Equals("Player"))
        {
            cekButton = false;
            btnInteract.SetActive(false);
            //Hapus Pop Up Button
            HiddenText();
        }
    }
     
    //Fungsi untuk menampilkan poster
    private void ShowPoster()
    {
        Time.timeScale = 0;
        cekPoster = true;
        posterFull.SetActive(true);
        anim.SetBool("FadeIn", true);
        
        //khusus video seminar
        if(this.name==("SeminarBOS_Panel"))
        {
            Player.SetActive(false);
            PlayerSitCam.SetActive(true);
            NoMainChar.SetActive(false);
            if (Data.CharNum == 1)
            {
                MainChar1.SetActive(true);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 2)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(true);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 3)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(true);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 4)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(true);
            }
        }
        else if (this.name == ("SeminarAAE_Panel "))
        {
            Player.SetActive(false);
            PlayerSitCam.SetActive(true);
            NoMainChar.SetActive(false);
            if (Data.CharNum == 1)
            {
                MainChar1.SetActive(true);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 2)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(true);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 3)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(true);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 4)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(true);
            }
        }
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
     //   textButton.enabled = true;
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
        yield return new WaitForSeconds((float)0.5);
        posterFull.SetActive(false);
        if(coinAlreadyPicked==0)
        {
            ShowCoin();
        }
    }

    public void ClosePoster()
    {
        print("Close Poster");
        StartCoroutine(AnimHiddenPoster());
        //khusus video seminar
        if (this.name == ("SeminarBOS_Panel"))
        {
            NoMainChar.SetActive(true);
            PleaseSitSign.SetActive(false);
            Player.SetActive(true);
            PlayerSitCam.SetActive(false);
            if (Data.CharNum == 1)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 2)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 3)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 4)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
        }
        else if (this.name == ("SeminarAAE_Panel "))
        {
            NoMainChar.SetActive(true);
            PleaseSitSign.SetActive(false);
            Player.SetActive(true);
            PlayerSitCam.SetActive(false);
            if (Data.CharNum == 1)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 2)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 3)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
            else if (Data.CharNum == 4)
            {
                MainChar1.SetActive(false);
                MainChar2.SetActive(false);
                MainChar3.SetActive(false);
                MainChar4.SetActive(false);
            }
        }
    }

    public void ShowCoin()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
        if (coin != null)
            coin.SetActive(true);   
    }
    
    public void Interact()
    {
        if (cekButton)
        {
            btnInteract.SetActive(false);
            PlayerPrefs.SetInt("GetCoin", 1);
            ShowPoster();
        }
    }

    //khusus video seminar
    public void VideoIsSeminarBOS()
    {
        PleaseSitSign.SetActive(true);
        SeminarBOS.SetActive(true);
        SeminarAAE.SetActive(false);
    }
    public void VideoIsSeminarAAE()
    {
        PleaseSitSign.SetActive(true);
        SeminarBOS.SetActive(false);
        SeminarAAE.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
