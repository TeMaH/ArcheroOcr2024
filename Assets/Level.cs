using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform[] enemiesPos;
    [SerializeField] private Transform heroPos;

    private string _nextSceneName;

    public static Level Instance { get; private set; }

    public Action OnLevelComplete;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnLevelComplete?.Invoke();
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GateTrigger.Instance.OnGateTriggered += LoadNextLevel;
        LoadLevelManager.OnLevelComplete += ctx => _nextSceneName = ctx;
    }

    public Transform[] GetEnemiesPos()
    {
        return enemiesPos;
    }

    public Transform GetHeroPos()
    {
        return heroPos;
    }
    
    private void LoadNextLevel()
    {
        Debug.Log("Load next Level");
        SceneManager.LoadScene(_nextSceneName);
    }

    private void OnDestroy()
    {
        GateTrigger.Instance.OnGateTriggered -= LoadNextLevel;
    }
}
