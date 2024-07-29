using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeapon : MonoBehaviour, IStats
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
        Name = "NoWeapon";
        Health = 10;
        Attack = 20;
        Defense = 30;
        Speed = 100;
        Level = 9;
        IsBought = true;
        About = "Assist";
        Price = 80000;
    }
    
}
