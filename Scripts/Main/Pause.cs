using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pause;
    private int PointerID;
    private bool Touched;
    public GameObject PauseMenu;

    public AudioSource click_pause;

    private void Awake()
    {
        Touched = false;
        pause = false;
    }

    /*void OnMouseDown()
    {
        if (!pause)
        {
            Time.timeScale = 0;

            pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
        }
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Touched)
        {
            Touched = true;
            PointerID = eventData.pointerId;
            if (!pause)
            {
                Time.timeScale = 0f;
                click_pause.Play();
                PauseMenu.SetActive(true);

                pause = false;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == PointerID);
        Touched = false;
    }

}
