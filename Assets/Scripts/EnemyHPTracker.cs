using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHPTracker : MonoBehaviour
{
    [SerializeField] int HPMax = 5;

    [Tooltip("Adds the value in this field to the HPMax when the enemy dies.")]
    [SerializeField] int HPRampOnDeath = 1;
    [SerializeField] int hitPoints; //deserialize on "release" build

    Enemy thisEnemy;

    // OnEnable is called whenever this component is enabled
    void OnEnable()
    {
        Resurrect();
    }

    private void Start()
    {
        thisEnemy = gameObject.GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        DamageMe();
    }

    private void DamageMe()
    {
        hitPoints--;
        if(hitPoints <= 0)
        {
            gameObject.SetActive(false);
            HPMax += HPRampOnDeath;
            thisEnemy.RewardGold();
        }
    }

    private void Resurrect()
    {
        hitPoints = HPMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
