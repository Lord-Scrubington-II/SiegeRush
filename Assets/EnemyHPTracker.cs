using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPTracker : MonoBehaviour
{
    [SerializeField] int HPMax = 5;
    [SerializeField] int hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = HPMax;
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
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
