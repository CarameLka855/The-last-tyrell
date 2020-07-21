using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Level_Up : MonoBehaviour
{
    public Hero_script hero_hp_cur;
    public Hero_script hero_hp_max;
    public Hero_script damager_hero;
    public Enemy_script curHealthEnemy;
    public Enemy_script maxHealthEnemy;
    public Enemy_script damager_enemy;
    public respawn_enemy kolvo_enemy;
    public Enemy_script speed_enemy;
    public Text ScoreText;
    public Text Next_Leveling;
    public GameObject Level_Text;
    public int Score;
    public int Global_Score;
    public int Level;
    private int uvel;

    public GameObject Win;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public Text Score_Text;
    public GameObject NExt;
    public GameObject Menu;
    public GameObject Quit;
    //public AudioSource Star_fall;

    public Text time;
    private float GameSecondsS = 1;
    private float GameSeconds;
    private float GameMinutes;

    string stringSecond;
    string stringMinutes;

    public AudioSource Win_Sound;
    public AudioSource Backgr;
    public AudioSource click;

    private float Second_to_kill;
    private float Second_to_go_zombie;

    void Start()
    {
        kolvo_enemy.kolvo_enemy = 5;
        hero_hp_cur.curHealthHero = 100;
        hero_hp_max.maxHealthHero = 100;
        damager_hero.damager_hero = 20;
        curHealthEnemy.curHealthEnemy = 100;
        maxHealthEnemy.maxHealthEnemy = 100;
        damager_enemy.damager_enemy = 10;
        speed_enemy.speed = 0.05f;
        uvel = 0;

        Score = 0;

        UpdateScore();

        Level = 0;

        StartCoroutine(Clocks());

        Second_to_kill = 6;
        Second_to_go_zombie = 6;
    }


    void Update()
    {

      //Clock();

        Next_Leveling_Menu();
    }

    public IEnumerator Clocks()
    {
        for (int i = 0; i < GameSecondsS; i++)
        {
            GameSecondsS += 1;
            GameSeconds += 1;
            yield return new WaitForSeconds(1f);
            stringSecond = GameSeconds.ToString();
            stringMinutes = GameMinutes.ToString();
            time.text = "Time: " + stringMinutes + ":" + stringSecond;

            if (GameSeconds >= 60.0f)
            {
                GameMinutes = GameMinutes + 1.0f;
                GameSeconds = 0;
            }
        }
    }

    /*void Clock()
    {
        GameSecondsS = GameSecondsS + Time.deltaTime;

        stringSecond = GameSeconds.ToString();
        stringMinutes = GameMinutes.ToString();

        time.text = "Время: " + stringMinutes + ":" + stringSecond;

        if (GameSecondsS >= 60.0f)
        {
            GameSeconds = GameSeconds + 1.0f;
            GameSecondsS = 0;
        }
        if (GameSeconds >= 60.0f)
        {
            GameMinutes = GameMinutes + 1.0f;
            GameSeconds = 0;
        }
    }*/

    void UpdateScore()
    {
        ScoreText.text = "Score: " + Global_Score;
    }

    public void AddScore(int NewScoreValue)
    {
        Score += NewScoreValue;
        Global_Score += NewScoreValue;
        UpdateScore();
    }

    void DelattoWin()
    {
        Time.timeScale = 0f;
    }

    void Star1_time()
    {
        Star1.SetActive(true);
        //Star_fall.Play();
    }

    void Star2_time()
    {
        Star2.SetActive(true);
        //Star_fall.Play();
    }

    void Star3_time()
    {
        Star3.SetActive(true);
        //Star_fall.Play();
    }

    public IEnumerator Menus_Next()
    {
        yield return new WaitForSeconds(3f);
        NExt.SetActive(true);
        Menu.SetActive(true);
        Quit.SetActive(true);
    }

    void Next_Leveling_Menu()
    {
        float Time_to_Stars = kolvo_enemy.kolvo_enemy * (Second_to_kill + Second_to_go_zombie);
        if (Score == kolvo_enemy.kolvo_enemy)
        {
            Backgr.Pause();
            Win_Sound.Play();
            Score_Text.text = Global_Score.ToString();
            Score = 0;
            StartCoroutine(Menus_Next());
            Invoke("DelattoWin", 3f);
            Win.SetActive(true);
            if (GameMinutes * 60 + GameSeconds >= Time_to_Stars + 15)
                Invoke("Star1_time", 1f);
            else if (GameMinutes * 60 + GameSeconds > Time_to_Stars && GameMinutes * 60 + GameSeconds < Time_to_Stars + 15)
            {
                Invoke("Star1_time", 1f);
                Invoke("Star2_time", 2f);
            }
            else if (GameMinutes * 60 + GameSeconds <= Time_to_Stars)
            {
                Invoke("Star1_time", 1f);
                Invoke("Star2_time", 2f);
                Invoke("Star3_time", 3f);
            }
        }

    }

    /*void Next_Level()
     {
         if (Score == kolvo_enemy.kolvo_enemy)
         {

             Level += 1;
             uvel += 5;
            Next_Leveling.text = "LEVEL " + Level + "";
             Invoke("ResetFlag", 3);
            kolvo_enemy.kolvo_enemy += 20 + uvel;
            curHealthEnemy.curHealthEnemy += 5;
            maxHealthEnemy.maxHealthEnemy += 5;
            damager_enemy.damager_enemy += 5;
            hero_hp_cur.curHealthHero = 100;
         }
     }*/

    /*void ResetFlag()
    {
        Next_Leveling.text = " ";
    }*/

    void Delay_TextLevel()
    {
        Level_Text.SetActive(false);
    }

    public void Next_Level()
    {
        NExt.SetActive(false);
        Menu.SetActive(false);
        Quit.SetActive(false);
        Level += 1;
        Level_Text.SetActive(true);
        Next_Leveling.text = "LEVEL " + Level;
        Invoke("Delay_TextLevel", 1f);
        click.Play();
        Backgr.Play();
        Time.timeScale = 1f;
        Win.SetActive(false);
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        GameSeconds = 0;
        GameMinutes = 0;
        uvel += 5;
        kolvo_enemy.kolvo_enemy = 0;
        kolvo_enemy.kolvo_enemy = 5 + uvel;
        curHealthEnemy.curHealthEnemy += 5;
        maxHealthEnemy.maxHealthEnemy += 5;
        damager_enemy.damager_enemy += 5;
        speed_enemy.speed += 0.005f;
        hero_hp_cur.curHealthHero = 100;
        Second_to_kill += 0.05f;
        kolvo_enemy.New_Spawn();
    }

}


