using System.Collections;
using UnityEngine;

public class respawn_enemy : MonoBehaviour
{
    public GameObject zeleton;
    public int kolvo_enemy;
    public AudioSource Rise;

    public Camera cam;
    public float minX, maxX;
    Vector2 centrCam;
    float widthCam;

    void Start()
    {
        widthCam = cam.orthographicSize * cam.aspect;
        centrCam = cam.transform.position;
        minX = centrCam.x - widthCam + 0.2f;
        maxX = centrCam.x + widthCam - 0.2f;

        StartCoroutine(Spawn());
    }

    void Awake()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
    }

    IEnumerator Spawn()
    {

            for (int i = 0; i < kolvo_enemy; i++)
            {
                Rise.Play();
                Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(-3.4f, 2.68f), 0);
                Instantiate(zeleton, position, Quaternion.identity);// появление врага в рандомной позиции диапазона
                yield return new WaitForSeconds(3f); // задержка при появлении нового врага
            }
    }

    public void New_Spawn()
    {
        StartCoroutine(Spawn());
    }
}
