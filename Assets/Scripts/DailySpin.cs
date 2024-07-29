using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailySpin : MonoBehaviour
{
    public Action TestForOpeningChest;
    public Action SpinRunOut;
    [SerializeField] private TextMeshProUGUI _currentSpinsText;
    [SerializeField] private GameObject _presentButton;
    private int _currentSpins = 3;

    public void CountSpins()
    {
        _currentSpins -= 1;
        if (_currentSpins > 0)
        {
            _currentSpinsText.text = $"x {_currentSpins.ToString()}";
        }
        else
        {
            _currentSpinsText.text = "x 0";
            SpinRunOut?.Invoke();
            _presentButton.SetActive(false);
            
        }
    }

    public void OpenChestAnimation()
    {
        if (_currentSpins <= 0)
        {
            TestForOpeningChest?.Invoke();
        }
    }
    
    private void Awake()
    {
        _currentSpinsText.text ="x " + _currentSpins;
    }
}
