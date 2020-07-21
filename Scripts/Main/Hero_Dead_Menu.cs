using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero_Dead_Menu : MonoBehaviour
{
    public GameObject Dead_Hero_Menu1;
    public Text ScoreAll;
    public AudioSource click;
    public Level_Up Score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreALL();
    }

    void ScoreALL()
    {
        ScoreAll.text = "Your Score: " + Score.Global_Score;
    }

    public void Retry()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
