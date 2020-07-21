using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Attack : MonoBehaviour
{
    static GameObject NearTarger(Vector3 position, Collider2D[] array)
    {
        Collider2D current = null;
        float dist = Mathf.Infinity;

        foreach (Collider2D coll in array)
        {
            float curDist = Vector3.Distance(position, coll.transform.position);

                if(curDist <dist)
                {
                    current = coll;
                    dist = curDist;
                }
        }

        return (current != null) ? current.gameObject : null;
    }

    public static void Action(Vector2 point, float radius, int layerMask, float damage, bool allTargets)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

        if(!allTargets)
        {
            GameObject obj = NearTarger(point, colliders);
            if(obj != null && obj.GetComponent<Enemy_script>())
            {
                obj.GetComponent<Enemy_script>().AddDamage(-damage);
            }
            return;

        }

        foreach(Collider2D hit in colliders)
        {
            if(hit.GetComponent<Enemy_script>())
            {
                hit.GetComponent<Enemy_script>().AddDamage(-damage);
            }
        }
    }

}
