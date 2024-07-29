using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandsSword : MonoBehaviour, IStats
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
        Name = "TwoHandsSword";
        Health = 100;
        Attack = 110;
        Defense = 60;
        Speed = 50;
        Level = 4;
        IsBought = false;
        About = "Arms warrior";
        Price = 24000;
    }
}
