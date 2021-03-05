using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Door : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private Text textButton;

    [SerializeField] private string scene;

    bool cekButton;
    private void Start()
    {
        cekButton = false;
        HiddenText();

        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && cekButton)
        {
            StartCoroutine(PindahScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            ShowText();
            cekButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            cekButton = false;
            HiddenText();
        }
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

    IEnumerator PindahScene()
    {
        anim.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("FadeIn", false);
        PlayerPrefs.SetInt("Coin", Data.coin);
        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeOut()
    {
        anim.SetBool("FadeOut", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("FadeOut", false);
    }
}
