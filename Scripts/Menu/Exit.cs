using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public AudioSource click_exit;

    void OnMouseDown()
    {
        click_exit.Play();
        Application.Quit();
    }
}
