using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.testScripts;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private AddPresentView _addPresentView;
    [SerializeField] private ChestView _chestView;
    [SerializeField] private BackView _backView;
    [SerializeField] private DailySpinView _dailySpinView;
    
    public void PlayAnimation(TypeTest type)
    {
        _backView.SetBackActive(true);
        _addPresentView.AddPresentAnimation(type);
    }

    public void PlayDailySpinAnimation()
    {
        _dailySpinView.PlayAnimation();
    }

    public void PlayOpeningChestAnimation()
    {
        _backView.SetBackActive(true);
        _chestView.OpeningChest();
    }
    
    private void Awake()
    {
        _addPresentView.AnimationFinished += _backView.SetBackActive;
        _addPresentView.PriseAdded += _chestView.PlayShaking;
        _chestView.TurnOnBack += _backView.SetBackActive;
    }

    private void OnDestroy()
    {
        _addPresentView.AnimationFinished -= _backView.SetBackActive;
        _addPresentView.PriseAdded -= _chestView.PlayShaking;
        _chestView.TurnOnBack -= _backView.SetBackActive;
    }
}
