using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Wheel : MonoBehaviour
{
    public Action RotationStarted;
    public Action<bool> TheRotationStopped;
    public Action<float, float> ControlSpeed;
    [SerializeField] private Button _homeButton; //!!!!!!!!!!!!!!!!!!!!!!!!
    [SerializeField] private GameObject _light;
    [SerializeField] private Button _button;
    private Rigidbody2D _rigidbody2D;
    private float _fixSpeed = 1.5f;
    private float _speed;
    private int _maxSpeed = 600;
    private int _minSpeed = 400;
    private Random _random = new();
    private bool _isRotate, _isThereSpin;

    public void Rotate()
    {
        if (!_isRotate && !_isThereSpin)
        {
            _homeButton.interactable = false; //!!!!!!!!!!!!!!!!!!!!!!!!!!
            _light.SetActive(true);
            RotationStarted.Invoke();
            _speed = GetRandomSpeed();
            _isRotate = true;
            StartCoroutine(Rotation());
            ControlSpeed?.Invoke(_speed, _fixSpeed);
        }

    }

    public void SpinIsEnded()
    {
        _button.interactable = false;
        _isThereSpin = false;
    }
    
    private IEnumerator Rotation()
    {
        var speed = _speed;
        while (speed > 0)
        {
            _rigidbody2D.angularVelocity = speed;
            speed -= _fixSpeed;
            yield return null;
        }
        _rigidbody2D.angularVelocity = 0;
        _isRotate = false;
        TheRotationStopped.Invoke(true);
        _light.SetActive(false);
        _homeButton.interactable = true; //!!!!!!!!!!!!!!!!!!!!!!!
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private float GetRandomSpeed()
    {
        return _random.Next(_minSpeed, _maxSpeed);
    }
}
