using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackView : MonoBehaviour
{
    [SerializeField] private GameObject _back;

    public void SetBackActive(bool state)
    {
        _back.SetActive(state);
    }
}
