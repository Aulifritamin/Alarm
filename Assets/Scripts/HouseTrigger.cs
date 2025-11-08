using System;
using System.Collections;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public event Action PlayerEntered;
    public event Action PlayerExited;

    private void OnTriggerEnter(Collider other)
    {
        PlayerEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerExited?.Invoke();
    }
}
