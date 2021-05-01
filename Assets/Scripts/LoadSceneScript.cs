using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneScript : MonoBehaviour
{
    private void Update()
    {
        if (Data.coin==162)
        {
            SceneManager.LoadScene("YouWinScene");
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Deskripsi");
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("YouWinScene");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
