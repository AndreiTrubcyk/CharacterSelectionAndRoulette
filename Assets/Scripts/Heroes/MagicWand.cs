using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : MonoBehaviour, IStats
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
        Name = "MagicWand";
        Health = 60;
        Attack = 100;
        Defense = 40;
        Speed = 100;
        Level = 6;
        IsBought = false;
        About = "Frost mage";
        Price = 12000;
    }
}
