using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShield : MonoBehaviour, IStats
{
    public string Name { get; private set; }
    public string About { get; private set;}
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Speed { get; private set; }
    public int Level { get; private set; }
    public int Price { get; private set; }
    public bool IsBought { get; set; }

    private void Awake()
    {
        Name = "SwordShield";
        Health = 110;
        Attack = 50;
        Defense = 100;
        Speed = 30;
        Level = 1;
        IsBought = false;
        About = "Tank";
        Price = 220000;
    }
}
