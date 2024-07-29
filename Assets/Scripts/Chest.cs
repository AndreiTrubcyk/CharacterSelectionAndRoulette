using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.testScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public UnityEvent CanOpen;
    public Action PlayOpeningAnimation;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private TextMeshProUGUI _diamonds;
    [SerializeField] private TextMeshProUGUI _heart;
    [SerializeField] private TextMeshProUGUI _mystery;
    [SerializeField] private Button _buttonChest;
    private Dictionary<TypeTest, int> _prizes = new();
    private Dictionary<TypeTest, TextMeshProUGUI> _testPresents;

    public void AddValueToPrize(TypeTest type, int value)
    {
        if (!_prizes.TryAdd(type, value))
        {
            _prizes[type] += value;
        }
    }

    public void TurnOnButton()
    {
        _buttonChest.interactable = true;
        CanOpen?.Invoke();
    }

    public void OpenChest()
    {
        foreach (var prize in _prizes)
        {
            _testPresents[prize.Key].text = prize.Value.ToString();
        }
        PlayOpeningAnimation?.Invoke();
    }

    private void Awake()
    {
        _testPresents = new Dictionary<TypeTest, TextMeshProUGUI>
        {
            { TypeTest.Coin, _coins },
            { TypeTest.Diamond, _diamonds },
            { TypeTest.Heart, _heart },
            { TypeTest.Mystery, _mystery },
        };
        _buttonChest.interactable = false;
    }
}
