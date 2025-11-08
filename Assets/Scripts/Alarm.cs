using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;
    private AudioSource _alarmSource;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    [SerializeField] private float _volumeChangeSpeed = 0.2f;
    private Coroutine _fadeCoroutine;

    private void Awake()
    {
        _alarmSource = GetComponent<AudioSource>();
        _alarmSource.volume = _minVolume;
        _alarmSource.clip = _alarmSound;
        _alarmSource.loop = true;
        _alarmSource.playOnAwake = false;
    }

    public void TurnOn()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _alarmSource.Play();
        _fadeCoroutine = StartCoroutine(FadeVolume(_maxVolume));
    }

    public void TurnOff()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _fadeCoroutine = StartCoroutine(FadeVolume(_minVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        while (_alarmSource.volume != targetVolume)
        {
            _alarmSource.volume = Mathf.MoveTowards(_alarmSource.volume, targetVolume, _volumeChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (_alarmSource.volume == _minVolume)
        {
            _alarmSource.Stop();
        }
    }
}
