using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controller_move : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler, IDragHandler
{ 
    public GameObject Controller_Touch;
    Vector3 Target_Vector;
    public Hero_script Hero_Move;

    // Start is called before the first frame update
    void Start()
    {
        Controller_Touch.transform.position = transform .position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touch_pos = Input.mousePosition;
            Target_Vector = touch_pos - transform.position;

            if (Target_Vector.magnitude < 125)
            {
                Controller_Touch.transform.position = touch_pos;
                Hero_Move.Target_Move = Target_Vector;
            }
        }
        else
        {
            Controller_Touch.transform.position = transform.position;
            Hero_Move.Target_Move = new Vector3(0, 0, 0);
        }
    }
/*
    private int PointerID;
    private bool Touched;

    private void Awake()
    {
        Touched = false;
        Controller_Touch.transform.position = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!Touched)
        {
            Touched = true;
            PointerID = eventData.pointerId;
            Vector3 touch_pos = eventData.position;
            Target_Vector = touch_pos - transform.position;

            if (Target_Vector.magnitude < 100)
            {
                Controller_Touch.transform.position = touch_pos;
                Hero_Move.Target_Move = Target_Vector;

            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 touch_pos = eventData.position;
        Target_Vector = touch_pos - transform.position;

        if (Target_Vector.magnitude < 100)
        {
            Controller_Touch.transform.position = touch_pos;
            Hero_Move.Target_Move = Target_Vector;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == PointerID);
        Touched = false;
        Controller_Touch.transform.position = transform.position;
        Hero_Move.Target_Move = new Vector3(0, 0, 0);
    }
    */
}
