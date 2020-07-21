using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgr_resol : MonoBehaviour
{
    public Vector2 bottomLeft;
    public Vector2 topRight;
    float height, width;

    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = MainCamera.ScreenToWorldPoint(Vector2.zero);
        topRight = MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        height = topRight.y - bottomLeft.y;
        width = topRight.x - bottomLeft.x;

        transform.localScale = new Vector3(width / 19.2f, height/10.7f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
