using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldDropQuantity = 25;
    [SerializeField] int goldTheftQuantity = 25;

    Treasury masterTreasury;

    // Start is called before the first frame update
    void Start()
    {
        masterTreasury = FindObjectOfType<Treasury>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RewardGold()
    {
        if(masterTreasury == null)
        {
            throw new UnassignedReferenceException("Attempted to deposit gold into a null-valued treasury.");
        }
        masterTreasury.Deposit(goldDropQuantity);
    }

    public void StealGold()
    {
        if (masterTreasury == null)
        {
            throw new UnassignedReferenceException("Attempted to withdraw gold from a null-valued treasury.");
        }
        masterTreasury.Withdraw(goldTheftQuantity);
    }
}
