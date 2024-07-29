using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSword : MonoBehaviour, IStats
{
    public string Name { get; private set; }
    public string About { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Speed { get; private set; }
    public int Level { get; private set; }
    public int Price { get; private set; }
    public bool IsBought { get; set; }

    private void Awake()
    {
        Name = "DoubleSword";
        Health = 90;
        Attack = 90;
        Defense = 70;
        Speed = 20;
        Level = 3;
        IsBought = false;
        About = "Fury warrior";
        Price = 40000;
    }
}
