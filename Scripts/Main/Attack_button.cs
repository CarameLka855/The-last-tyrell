using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack_button : MonoBehaviour
{
    bool flag = false;
    public Hero_script ADr;

    private void OnMouseDown()
    {
        ADr.flag = true;
    }

    private void OnMouseUp()
    {
        ADr.flag = false;
    }
    
}