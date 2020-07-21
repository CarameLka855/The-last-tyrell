using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Wait_and_New_Scene : MonoBehaviour
{
    public static IEnumerator WaitTime()
    {
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main");
    }
}

