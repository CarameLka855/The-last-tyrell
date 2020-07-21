using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_script : MonoBehaviour
{
    public float speed;
    [SerializeField]
    public Vector3 Target_Move;
    private Animator anim;

    public Transform punch;
    public float punchRadius;

    public float curHealthHero = 100;
    public GameObject healthObj;
    public float maxHealthHero = 100;
    public bool flag;
    public bool attack;
    public int damager_hero;
    public Hit_zone Button_hit;
    public float fireRate = 1.0F;
    private float nextFire = 0.0F;
    public GameObject DeadMenu;

    //public AudioSource Dead_Menu_Sound;
    public AudioSource Backgr;
    public AudioSource Rise_Enemy;
    public AudioSource Sword_hit;

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

        punchRadius = 0.2f;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.42f, 2.73f), transform.position.z);

        transform.Translate(Target_Move * speed * Time.deltaTime);

        if (Target_Move.x > 0f && Target_Move.y <= 10f && Target_Move.y >= -10f)
        {
            anim.SetInteger("HeroAnim", 3); //right
        }
        else if (Target_Move.x < 0f && Target_Move.y <= 10f && Target_Move.y >= -10f)
        {
            anim.SetInteger("HeroAnim", 4); //left
        }
        else if (Target_Move.x >= 5f && Target_Move.y >= 5f && Target_Move.y <= 100f)
        {
            anim.SetInteger("HeroAnim", 9); //up right
        }
        else if (Target_Move.x < -5f && Target_Move.y >= 5f && Target_Move.y <= 100f)
        {
            anim.SetInteger("HeroAnim", 8); //up left
        }
        else if (Target_Move.y > 0f && Target_Move.x <= 10f && Target_Move.x >= -10f)
        {
            anim.SetInteger("HeroAnim", 1); //up 
        }
        else if (Target_Move.y < 0f && Target_Move.x <= 10f && Target_Move.x >= -10f)
        {
            anim.SetInteger("HeroAnim", 5); //down
        }
        else if (Target_Move.x > 5f && Target_Move.y <= -5f && Target_Move.y >= -100f)
        {
            anim.SetInteger("HeroAnim", 10); //down right
        }
        else if (Target_Move.x < -5f && Target_Move.y <= -5f && Target_Move.y >= -100f)
        {
            anim.SetInteger("HeroAnim", 11); //down left
        }

        else
            anim.SetInteger("HeroAnim", 2);

        healthObj.transform.localScale = new Vector3(curHealthHero / maxHealthHero, 1, 1);

        /*if(flag)
        {
                flag = false;
                anim.SetInteger("HeroAnim", 6);
                Hero_Attack.Action(punch.position, punchRadius, 9, damager_hero, false);
            
        }*/
        if (Button_hit.canhit() && Time.time > nextFire)
        {
            anim.SetInteger("HeroAnim", 6);
            nextFire = Time.time + fireRate;
            Sword_hit.Play();
            Hero_Attack.Action(punch.position, punchRadius, 9, damager_hero, false);
        }


    }


    /*public void Attack()
    {
        if (attack == true)
        {
            attack = false;
            anim.SetInteger("HeroAnim", 6);
            Hero_Attack.Action(punch.position, punchRadius, 9, 50, false);
            Invoke("AttackReset", 1);
        }
    }*/

    /*public void AttackReset()
    {
        attack = true;
    }*/


    public void AddDamage_Hero(float damage)
    {
        curHealthHero += damage;

        if (curHealthHero <= 0)
        {
            Backgr.Pause();
            Rise_Enemy.Pause();
            curHealthHero = 0;
            DeadMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}