using UnityEngine;

public class move_character : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float speed = 10f;


    void OnMouseDrag ()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        mousePos.x = mousePos.x < -7.02f ? -7.02f : mousePos.x;
        mousePos.x = mousePos.x > 7.01f ? 7.01f : mousePos.x;
        mousePos.y = mousePos.y < -2.5f ? -2.5f : mousePos.y;
        mousePos.y = mousePos.y > 4.49f ? 4.49f : mousePos.y;
        player.position = Vector2.MoveTowards (player.position, new Vector2(mousePos.x, mousePos.y), speed * Time.deltaTime);
    }
}
