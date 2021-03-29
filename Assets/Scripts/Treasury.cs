using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Treasury : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI goldDisplay;
    //[SerializeField] int ballistaPrice;

    public int Balance { get => currentBalance; private set => currentBalance = value; }
    //public int BallistaPrice { get => ballistaPrice; private set => ballistaPrice = value; }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateGoldDisplay();
    }

    public void Deposit(int quantity)
    {
        if(quantity < 0)
        {
            throw new System.Exception("Attempted to deposit a negative quantity.");
        }
        currentBalance += quantity;
        UpdateGoldDisplay();
    }

    public void Withdraw(int quantity)
    {
        if (quantity < 0)
        {
            throw new System.Exception("Attempted to deposit a negative quantity.");
        }
        currentBalance -= quantity;

        if(currentBalance < 0)
        {
            ReloadScene(); // temp
        }
        UpdateGoldDisplay();
    }


    void UpdateGoldDisplay()
    {
        goldDisplay.text = $"Gold: {Balance}"; 
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
