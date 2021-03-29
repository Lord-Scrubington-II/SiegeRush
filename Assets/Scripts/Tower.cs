using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int price = 75;

    public int Price { get => price; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal bool BuildTower(Tower towerPrefab, Vector3 parent)
    {
        Treasury treasury = FindObjectOfType<Treasury>();

        if (treasury == null || treasury.Balance <= 0)
        {
            return false;
        } 
        
        if(treasury.Balance >= price)
        {
            GameObject.Instantiate(towerPrefab, parent, Quaternion.identity);
            treasury.Withdraw(price);
            return true;
        }

        return false;
    }
}
