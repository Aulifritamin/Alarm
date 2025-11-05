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
    private float _delta = 0.2f;

    private bool _isPlayerInside = false;

    private void Awake()
    {
        _alarmSource = GetComponent<AudioSource>();
        _alarmSource.volume = _minVolume;
        _alarmSource.clip = _alarmSound;
    }

    private void Update()
    {
        if( _isPlayerInside )
        {
            VolumeController(_maxVolume);
        }
        else
        {
            if( _minVolume == _alarmSource.volume)
            {
                _alarmSource.Stop();
            }
            else
            {
                VolumeController(_minVolume);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInside = !_isPlayerInside;
        _alarmSource.Play();
    }

    private void VolumeController(float targetVolume)
    {
        _alarmSource.volume = Mathf.MoveTowards(_alarmSource.volume, targetVolume, _delta * Time.deltaTime);
    }
}
