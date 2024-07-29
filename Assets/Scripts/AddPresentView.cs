using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.testScripts;
using Unity.VisualScripting;
using UnityEngine;

public class AddPresentView : MonoBehaviour
{
    public Action<bool> AnimationFinished;
    public Action PriseAdded;
    [SerializeField] private Animator _coin;
    [SerializeField] private Animator _diamond;
    [SerializeField] private Animator _heart;
    [SerializeField] private Animator _mystery;
    [SerializeField] private Animator _scull;

    private const string _addToChestAnimation = "AddToChest";
    private const string _scullAnimation = "ScullAnimation";

    private Dictionary<TypeTest, Animator> _animations;
    private Animator _currentAnimator;
    
    public void AddPresentAnimation(TypeTest type)
    {
        _currentAnimator = _animations[type];
        StartCoroutine(Play());
    }
    
    private IEnumerator Play()
    {
        if (_currentAnimator != _scull)
        {
            _currentAnimator.Play(_addToChestAnimation);
            yield return StartCoroutine(WaitForAnimationToEnd(_addToChestAnimation, _currentAnimator));
            PriseAdded.Invoke();
        }
        else
        {
            _currentAnimator.Play(_scullAnimation);
            yield return StartCoroutine(WaitForAnimationToEnd(_scullAnimation, _currentAnimator));
        }
        
        AnimationFinished.Invoke(false);
    }
    
    private IEnumerator WaitForAnimationToEnd(string animationName, Animator animator)
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && 
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
    }
    
    private void Awake()
    {
        _animations = new Dictionary<TypeTest, Animator>
        {
            { TypeTest.Coin , _coin},
            { TypeTest.Diamond , _diamond},
            {TypeTest.Heart, _heart},
            { TypeTest.Mystery , _mystery},
            { TypeTest.Scull , _scull}
        };
    }
}
