using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.testScripts;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityEvent<TypeTest> PlayAnimation;
    public UnityEvent<TypeTest> PlaySound;
    public UnityEvent<TypeTest, int> UsingCurrentPrize;
    [SerializeField] private TypeTest _typeOfPrize;
    [SerializeField] private int _value;

    public void Pick()
    {
        UsingCurrentPrize?.Invoke(_typeOfPrize, _value);
        PlayAnimation?.Invoke(_typeOfPrize);
        PlaySound?.Invoke(_typeOfPrize);
    }
}
