using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Action SentPresent;
    private bool _isRotateStopped;
    
    public void RotationStopped(bool state)
    {
        _isRotateStopped = state;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (_isRotateStopped)
        {
            var present = collider.gameObject.GetComponent<Item>();
            present.Pick();
            _isRotateStopped = false;
            SentPresent?.Invoke();
        }
    }
}
