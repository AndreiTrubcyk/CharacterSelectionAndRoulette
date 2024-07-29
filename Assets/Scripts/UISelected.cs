using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelected : MonoBehaviour
{
    [SerializeField] private RectTransform _health;
    [SerializeField] private RectTransform _attack;
    [SerializeField] private RectTransform _defense;
    [SerializeField] private RectTransform _speed;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _aboutHero;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _price;
    private int _allMoney;

    private void Awake()
    {
        _allMoney = int.Parse(_price.text);
    }


    public void Set(IStats hero)
    {
        _name.text = hero.Name;
        _level.text = hero.Level.ToString();
        _aboutHero.text = hero.About;
        
        var health = _health.sizeDelta;
        health.x = hero.Health;
        _health.sizeDelta = health;

        var attack = _attack.sizeDelta;
        attack.x = hero.Attack;
        _attack.sizeDelta = attack;

        var defense = _defense.sizeDelta;
        defense.x = hero.Defense;
        _defense.sizeDelta = defense;

        var speed = _speed.sizeDelta;
        speed.x = hero.Speed;
        _speed.sizeDelta = speed;
    }

    public void ChangeButtonStatus(bool status)
    {
        _selectButton.interactable = status;
    }

    public void Buy(bool status)
    {
        _buyButton.gameObject.SetActive(status);
    }
    
    public void Pay(int price)
    {
        _price.text = (_allMoney - price).ToString();
    }
}
