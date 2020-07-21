using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Going_on_first_scene : MonoBehaviour
{
    public GameObject hero;
    public GameObject Text;
    public GameObject Intro_text;
    [SerializeField]
    private float going_speed = 1f;
    public bool flag = false;
    public AudioSource step_by_step;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        step_by_step.Play();
    }

    void Update ()
    {
        if (hero.gameObject.transform.position.y < 2.68f)
        {
            anim.SetInteger("HeroAnim", 1);
            //step_by_step.Play();
            transform.position += new Vector3(0, going_speed * Time.deltaTime, 0);
        }
        else
        {
            step_by_step.Pause();
            going_speed = 0;
            anim.SetInteger("HeroAnim", 2);
            flag = true;
            Intro_text.SetActive(flag);
            Text.SetActive(flag);
            StartCoroutine(Wait_and_New_Scene.WaitTime()); // вызов подфункции 
        }
    }

}
