using System;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public Action OnGateTriggered;
    public static GateTrigger Instance { get; private set; }

    private bool _isActive = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadLevelManager.OnLevelComplete += ctx =>
        {
            Debug.Log("Gate activated");
            _isActive = true;
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive && other.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Player entered Trigger");
        OnGateTriggered?.Invoke();
    }
}