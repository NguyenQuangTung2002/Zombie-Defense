using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance;

    public int coins;
    public int gemStone;

    private TextMeshProUGUI textCoins;
    private TextMeshProUGUI textGems;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        textCoins = GetComponentsInChildren<TextMeshProUGUI>()[0];
        textGems = GetComponentsInChildren<TextMeshProUGUI>()[1];
    }

    private void Update()
    {
        UpdateCoin(coins);
        UpdateGem(gemStone);
    }

    public void UpdateCoin(int coins)
    {
        textCoins.text = coins.ToString();
    }

    public void UpdateGem(int gems)
    {
        textGems.text = gems.ToString();
    }

    public void PaidCoins(int coin)
    {
        coins -= Math.Min(coins,coin);
    }

    public void PaidGems(int gems)
    {
        gemStone -= Math.Min(gemStone, gems);
    }
    
}
