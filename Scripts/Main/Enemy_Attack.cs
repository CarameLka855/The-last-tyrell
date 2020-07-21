using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{

    static GameObject NearTarger_Hero(Vector3 position, Collider2D[] array)
    {
        Collider2D current = null;
        float dist = Mathf.Infinity;

        foreach (Collider2D coll in array)
        {
            float curDist = Vector3.Distance(position, coll.transform.position);

            if (curDist < dist)
            {
                current = coll;
                dist = curDist;
            }
        }

        return (current != null) ? current.gameObject : null;
    }


    public static void Action_Enemy(Vector2 point, float radius, int layerMask, float damage)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);
        GameObject obj = NearTarger_Hero(point, colliders);

        if (obj != null && obj.GetComponent<Hero_script>())
        {
                obj.GetComponent<Hero_script>().AddDamage_Hero(-damage * (Time.deltaTime * 0.5f));
            
        }
        return;

    }


}
