using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IStats
{
    public string Name { get; private set; }
    public string About { get; private set; }
    public int Health { get; private set;}
    public int Attack { get; private set;}
    public int Defense { get; private set;}
    public int Speed { get; private set;}
    public int Level { get; private set; }
    public int Price { get; private set; }
    public bool IsBought { get; set;}

    private void Awake()
    {
        Name = "Bow";
        Health = 50;
        Attack = 30;
        Defense = 20;
        Speed = 80;
        Level = 2;
        IsBought = false;
        About = "Archer";
        Price = 20000;
    }
}
