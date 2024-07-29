using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _prefabs;
    [SerializeField] private UISelected _uiSelected;
    [SerializeField] private UILobby _uiLobby;
    [SerializeField] private UIBackground _uiBackground;
    
    private IStats[] _heroes;
    private int _currentHero;
    private int _selectedHero;

    private void Awake()
    {
        _heroes = _prefabs.OfType<IStats>().ToArray();
        _uiSelected.Set(_heroes[_currentHero]);
        _uiLobby.Set(_heroes[_currentHero]);
        _heroes[_currentHero].IsBought = true;
        _uiSelected.Buy(false);
    }

    public void HeroButton()
    {
        _uiLobby.gameObject.SetActive(false);
        _uiSelected.gameObject.SetActive(true);
        _uiBackground.gameObject.SetActive(false);
        _uiSelected.Set(_heroes[_selectedHero]);
    }

    public void LeftArrow()
    {
        _prefabs[_currentHero].gameObject.SetActive(false);
        if (_currentHero == 0)
        {
            _currentHero = _prefabs.Length - 1;
        }
        else
        {
            _currentHero -= 1;
        }
        _prefabs[_currentHero].gameObject.SetActive(true);
        _uiSelected.Set(_heroes[_currentHero]);
        if (!_heroes[_currentHero].IsBought)
        {
            _uiSelected.ChangeButtonStatus(false);
            _uiSelected.Buy(true);
        }
        else
        {
            _uiSelected.ChangeButtonStatus(true);
            _uiSelected.Buy(false);
        }
    }

    public void RightArrow()
    {
        _prefabs[_currentHero].gameObject.SetActive(false);
        if (_currentHero == _heroes.Length - 1)
        {
            _currentHero = 0;
        }
        else
        {
            _currentHero += 1;
        }
        _prefabs[_currentHero].gameObject.SetActive(true);
        _uiSelected.Set(_heroes[_currentHero]);
        if (!_heroes[_currentHero].IsBought)
        {
            _uiSelected.ChangeButtonStatus(false);
            _uiSelected.Buy(true);
        }
        else
        {
            _uiSelected.ChangeButtonStatus(true);
            _uiSelected.Buy(false);
        }
    }

    public void HomeButton()
    {
        _uiLobby.gameObject.SetActive(true);
        _uiSelected.gameObject.SetActive(false);
        _uiBackground.gameObject.SetActive(true);
        _uiSelected.Set(_heroes[_selectedHero]);
        _prefabs[_currentHero].gameObject.SetActive(false);
        _prefabs[_selectedHero].gameObject.SetActive(true);
        _currentHero = _selectedHero;

    }

    public void SelectedButton()
    {
        _selectedHero = _currentHero;
        _uiSelected.Set(_heroes[_selectedHero]);
        _uiLobby.gameObject.SetActive(true);
        _uiLobby.Set(_heroes[_selectedHero]);
        _uiSelected.gameObject.SetActive(false);
        _uiBackground.gameObject.SetActive(true);
        
    }

    public void BuyButton()
    {
        _uiSelected.Buy(false);
        _heroes[_currentHero].IsBought = true;
        _uiSelected.ChangeButtonStatus(true);
        _uiLobby.Pay(_heroes[_currentHero].Price);
        _uiSelected.Pay(_heroes[_currentHero].Price);
    }
}
