using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public event Action<bool> DoorOpened;
    private bool _isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        _isOpen = true;
        DoorOpened?.Invoke(_isOpen);
    }

    private void OnTriggerExit(Collider other) 
    {
        _isOpen = false;
        DoorOpened?.Invoke(_isOpen);
    }
}
