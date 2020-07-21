using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_script : MonoBehaviour
{
    public Vector3 Target_Move;
    public float speed;
    private float speed_tet;
    [SerializeField]
    public Transform punch_enemy;
    public float punchRadius_enemy;
    private GameObject character;
    
    public float curHealthEnemy = 100;
    public GameObject healthObj_enemy;
    public float maxHealthEnemy = 100;

    public int damager_enemy;

   public float distance;

    private Animator anim;

    public int ScoreValue;
    private Level_Up level_Up;

    public AudioSource Dead;
    public AudioSource Hit;


    void Start()
    {
        punchRadius_enemy = 0.44f;
        speed_tet = speed;
        anim = GetComponent<Animator>();
        character = GameObject.Find("New_tyrell");

        GameObject GameControllerObject = GameObject.FindWithTag("Level_Up");
        if (GameControllerObject != null)
        {
            level_Up = GameControllerObject.GetComponent<Level_Up>();
        }

    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.62f, 8.62f), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.37f, 3.64f), transform.position.z);

        Target_Move = character.transform.position - transform.position;
        transform.Translate(Target_Move * speed * Time.deltaTime);

        distance = Target_Move.magnitude;

        if (Target_Move.x > 0f && Target_Move.y < 1.5f && Target_Move.y > -1.5f)
        {
            anim.SetInteger("Zeleton_action", 4); //right
            if (distance < 0.4)
            {
                speed = 0;
                anim.SetInteger("Zeleton_action", 8);
                Enemy_Attack.Action_Enemy(punch_enemy.position, punchRadius_enemy, 10, damager_enemy);
            }
            else speed = speed_tet;
            if (curHealthEnemy <= 0)
            {
                    speed = 0;
                    anim.SetInteger("Zeleton_action", 9);
            }
        }

        else if (Target_Move.x < 0f && Target_Move.y < 1.5f && Target_Move.y > -1.5f)
        {
            anim.SetInteger("Zeleton_action", 3); //left
            if (distance < 0.4)
            {
                speed = 0;
                anim.SetInteger("Zeleton_action", 7);
                Enemy_Attack.Action_Enemy(punch_enemy.position, punchRadius_enemy, 10, damager_enemy);
            }
            else speed = speed_tet;
            if (curHealthEnemy <= 0)
            {
                    speed = 0;
                    anim.SetInteger("Zeleton_action", 9);
             }
        }

        else if (Target_Move.y >= 1.5f && Target_Move.x <= 50f && Target_Move.x >= -50f)
        {
            anim.SetInteger("Zeleton_action", 1); //up
            if (distance < 0.4)
            {
                speed = 0;
                anim.SetInteger("Zeleton_action", 6);
                Enemy_Attack.Action_Enemy(punch_enemy.position, punchRadius_enemy, 10, damager_enemy);
            }
            if (curHealthEnemy <= 0)
            {
                    speed = 0;
                    anim.SetInteger("Zeleton_action", 9);
            }
        }
        else if (Target_Move.y <= -1.5f && Target_Move.x <= 50f && Target_Move.x >= -50f)
        {
            anim.SetInteger("Zeleton_action", 2); //down
            if (distance < 0.4)
            {
                speed = 0;
                anim.SetInteger("Zeleton_action", 5);
                Enemy_Attack.Action_Enemy(punch_enemy.position, punchRadius_enemy, 10, damager_enemy);
            }
            else speed = speed_tet;
            if (curHealthEnemy <= 0)
            {
                    speed = 0;
                    anim.SetInteger("Zeleton_action", 9);
            }
        }

        else
            anim.SetInteger("Zeleton_action", 0);

        healthObj_enemy.transform.localScale = new Vector3(curHealthEnemy / maxHealthEnemy, 1, 1); // полоска здоровья врагов



    }


    public void AddDamage(float damage)
    {
        curHealthEnemy += damage;
        Hit.Play();

        if (curHealthEnemy <= 0)
        {
            level_Up.AddScore(ScoreValue);
            Dead.Play();
            curHealthEnemy = 0;
            damager_enemy = 0;
            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Destroy", 1f);

        }
    }

    public void Destroy()
    {
        Destroy(gameObject); // удаляем объект
    }

}
