using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform turret;
    [SerializeField] float rangeMax = 15;
    [SerializeField] ParticleSystem projectiles;
    private Transform target;

    public delegate void TargetSelectorFunction();
    private TargetSelectorFunction FindTarget;

    // Start is called before the first frame update
    void Start()
    {
        FindTarget = FindTargetClosest;
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        AimTurret();
    }

    private void FindTargetClosest()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTargetLoc = null;
        float closestDistSoFar = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < closestDistSoFar)
            {
                closestTargetLoc = enemy.transform;
                closestDistSoFar = targetDistance;
            }
        }

        target = closestTargetLoc;
    }

    private void AimTurret()
    {
        float distFromTarget = Vector3.Distance(transform.position, target.position);
        turret.LookAt(target);

        if (distFromTarget < rangeMax)
        {
            SetAttacking(true);
        }
        else
        {
            SetAttacking(false);
        }        
    }

    void SetAttacking(bool isAttacking)
    {
        var emissionModule = projectiles.emission;
        emissionModule.enabled = isAttacking;
    }
}
