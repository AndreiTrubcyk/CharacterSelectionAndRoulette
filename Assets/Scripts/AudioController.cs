using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.testScripts;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _rotateSound;
    [SerializeField] private AudioSource _scullSound;
    [SerializeField] private AudioSource _heartSound;
    [SerializeField] private AudioSource _coinSound;
    [SerializeField] private AudioSource _diamondSound;
    [SerializeField] private AudioSource _mysterySound;
    [SerializeField] private AudioSource _claimSound;

    public void PlayWinSound(TypeTest type)
    {
        switch (type)
        {
            case TypeTest.Coin : _coinSound.Play();
                break;
            case TypeTest.Diamond : _diamondSound.Play();
                break;
            case TypeTest.Mystery : _mysterySound.Play();
                break;
            case TypeTest.Heart : _heartSound.Play();
                break;
            case TypeTest.Scull : _scullSound.Play();
                break;
        }
    }

    public void ClaimSound()
    {
        _claimSound.Play();
    }

    public void RotationSound(float speed, float fixSpeed)
    {
        _rotateSound.pitch = 1f;
        StartCoroutine(SoundCoroutine(speed, fixSpeed));
    }

    private IEnumerator SoundCoroutine(float speed, float fixSpeed)
    {
        var currentSpeed = speed;
        while (currentSpeed > 0)
        {
            currentSpeed -= fixSpeed;
            var soundSpeed = Mathf.InverseLerp(0, speed, currentSpeed);
            _rotateSound.pitch = soundSpeed;
            yield return null;
        }
    }
}
