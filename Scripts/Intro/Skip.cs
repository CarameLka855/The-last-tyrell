using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
    public GameObject ButtonSkip;
    private bool flag = true;
    public AudioSource click_skip;

    void Start()
    {
        StartCoroutine(fssf());
    }

    public void NextScene()
    {
        click_skip.Play();
        SceneManager.LoadScene("Main");

    }

    IEnumerator fssf()
    {
        yield return new WaitForSeconds(3f);
        ButtonSkip.SetActive(true);
    }
}
