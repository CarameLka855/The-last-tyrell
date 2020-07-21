using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public AudioSource click_start;

    void OnMouseDown()
    {
        click_start.Play();
        SceneManager.LoadScene("Intro");
    }

}
