using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hit_zone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{

    private int PointerID;
    private bool Touched;
    private bool CanHit;

    private void Awake()
    {
        Touched = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Touched)
        {
            CanHit = true;
            Touched = true;
            PointerID = eventData.pointerId;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == PointerID);
        Touched = false;
        CanHit = false;
    }

    public bool canhit()
    {
        return CanHit;
    }
}

