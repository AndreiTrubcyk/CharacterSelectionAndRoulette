using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILobby : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _price;
    private int _allMoney;

    private void Awake()
    {
        _allMoney = int.Parse(_price.text);
    }

    public void Pay(int price)
    {
        
        _price.text = (_allMoney - price).ToString();
    }

    public void Set(IStats hero)
    {
        _name.text = hero.Name;
    }
}
