using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLock : MonoBehaviour
{
    public Transform target;
    public float radius;
    public LayerMask targets;
    
    private void Update()
    {
        FindTarget();
    }

    void FindTarget()
    {
        Collider2D[] isEnemy = Physics2D.OverlapCircleAll(target.position, radius, targets);

        // Set first found
        Collider2D nearEnemy = null;
        float shortestDistance = Mathf.Infinity;

        for (int i = 0; i < isEnemy.Length; i++)
        {
            if (Vector3.Distance(transform.position, isEnemy[i].transform.position) < shortestDistance)
            {
                //shortestDistance = newDist;
                nearEnemy = isEnemy[i];
                transform.position = nearEnemy.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, nearEnemy.transform.position, 3f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(target.position, radius);
    }
}


