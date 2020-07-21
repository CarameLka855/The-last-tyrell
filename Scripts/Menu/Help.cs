using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject Help_Menu;
    public AudioSource click_start;

    public void Back()
    {
        click_start.Play();
        Help_Menu.SetActive(false);
    }

    public void Helping()
    {
        click_start.Play();
        Help_Menu.SetActive(true);
    }
}
