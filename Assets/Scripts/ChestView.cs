using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    public Action<bool> TurnOnBack;
    [SerializeField] private Animator[] _animators;
    [SerializeField] private Animator _chest;
    [SerializeField] private Button _claimButton;
    private static readonly int Test1 = Animator.StringToHash("test");
    private const string CHEST_SHAKE = "ChestShake";
    private const string SHOW_PRESENT = "ShowPresents";
    private const string HIDE_PRESENT = "HidePresent";
    
    public void PlayShaking()
    {
        _chest.Play(CHEST_SHAKE);
    }

    public void CanOpen()
    {
        _chest.SetTrigger(Test1);
    }

    public void OpeningChest()
    {
        StartCoroutine(Play(SHOW_PRESENT));
    }

    public void Claim()
    {
        foreach (var animator in _animators)
        {
            animator.Play(HIDE_PRESENT);
        }
        TurnOnBack?.Invoke(false);
        _chest.gameObject.SetActive(false);
        _claimButton.gameObject.SetActive(false);
    }

    private IEnumerator Play(string animation)
    {
        _claimButton.gameObject.SetActive(true);
        foreach (var animator in _animators)
        {
            animator.Play(animation);
            yield return new WaitForSeconds(0.5f);
        }

        _claimButton.interactable = true;
    }
}
