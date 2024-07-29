using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailySpinView : MonoBehaviour
{
    [SerializeField] private Animator _dailySpin;
    
    private const string JUMP_ANIMATION = "Jump";

    public void PlayAnimation()
    {
        _dailySpin.Play(JUMP_ANIMATION);
    }
}
