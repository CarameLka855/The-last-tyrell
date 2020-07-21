using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenu1;

    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Resume()
    {
        click.Play();
        PauseMenu1.SetActive(false);
        Time.timeScale = 1f;
    }

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
