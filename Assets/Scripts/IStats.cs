using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    public string Name { get;}
    public string About { get; }
    public int Health { get;}
    public int Attack { get;}
    public int Defense { get;}
    public int Speed { get;}
    public int Level { get; }
    public int Price { get; }
    public bool IsBought { get; set; }
}
