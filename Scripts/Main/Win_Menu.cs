using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Menu : MonoBehaviour
{
    public GameObject WinMenu;

    public AudioSource click;

    public void Menu()
    {
        click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        click.Play();
        Application.Quit();
    }
}
