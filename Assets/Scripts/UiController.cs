using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UiController : MonoBehaviour
{
    [SerializeField] private Wheel _rotationPart;
    [SerializeField] private Point _point;
    [SerializeField] private DailySpin _dailySpin;
    [SerializeField] private Chest _chest;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private AudioController _audioController;

    private void Awake()
    {
        _rotationPart.TheRotationStopped += _point.RotationStopped;
        _rotationPart.RotationStarted += _dailySpin.CountSpins;
        _dailySpin.SpinRunOut += _rotationPart.SpinIsEnded;
        _point.SentPresent += _dailySpin.OpenChestAnimation;
        _dailySpin.TestForOpeningChest += _chest.TurnOnButton;
        _rotationPart.RotationStarted += _animationController.PlayDailySpinAnimation;
        _chest.PlayOpeningAnimation += _animationController.PlayOpeningChestAnimation;
        _rotationPart.ControlSpeed += _audioController.RotationSound;
    }

    private void OnDestroy()
    {
        _rotationPart.TheRotationStopped -= _point.RotationStopped;
        _rotationPart.RotationStarted += _dailySpin.CountSpins;
        _dailySpin.SpinRunOut -= _rotationPart.SpinIsEnded;
        _point.SentPresent += _dailySpin.OpenChestAnimation;
        _dailySpin.TestForOpeningChest -= _chest.TurnOnButton;
        _rotationPart.RotationStarted -= _animationController.PlayDailySpinAnimation;
        _chest.PlayOpeningAnimation -= _animationController.PlayOpeningChestAnimation;
        _rotationPart.ControlSpeed -= _audioController.RotationSound;
    }
}
