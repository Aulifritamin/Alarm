using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    [SerializeField] private HouseTrigger _houseTrigger;

    private void OnEnable()
    {
        _houseTrigger.PlayerEntered += OnPlayerEntered;
        _houseTrigger.PlayerExited += OnPlayerExited;
    }

    private void OnDisable()
    {
        _houseTrigger.PlayerEntered -= OnPlayerEntered;
        _houseTrigger.PlayerExited -= OnPlayerExited;
    }

    private void OnPlayerEntered()
    {
        _alarm.TurnOn();
    }

    private void OnPlayerExited()
    {
        _alarm.TurnOff();
    }
}
