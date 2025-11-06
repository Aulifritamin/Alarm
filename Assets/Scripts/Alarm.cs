using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;
    [SerializeField] private Door _door;
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
        _alarmSource.loop = true;
        _alarmSource.playOnAwake = false;

        StartCoroutine(StartAlarm());
    }

    private void OnEnable()
    {
        _door.DoorOpened += EnterHouse;
    }

    private void OnDisable()
    {
        _door.DoorOpened -= EnterHouse;
    }

    private void EnterHouse(bool isOpen)
    {
        _isPlayerInside = isOpen;
    }

    private void VolumeController(float targetVolume)
    {
        _alarmSource.volume = Mathf.MoveTowards(_alarmSource.volume, targetVolume, _delta * Time.deltaTime);
    }

    private IEnumerator StartAlarm()
    {
        while(enabled) 
        {
            if (_isPlayerInside)
            {
                if(_alarmSource.isPlaying == false)
                {
                    _alarmSource.Play();
                }

                VolumeController(_maxVolume);
            }
            else
            {
                if(_alarmSource.volume <= _minVolume)
                {
                    _alarmSource.Stop();
                }

                VolumeController(_minVolume);
            }

            yield return null;
        }

    }
}
