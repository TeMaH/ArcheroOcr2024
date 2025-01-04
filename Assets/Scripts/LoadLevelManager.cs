using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LoadLevelManager : MonoBehaviour
{
    [SerializeField] private Level levelPrefab;
    [SerializeField] private GameObject heroPrefab;
    [SerializeField] private List<GameObject> enemiesPrefab;
    [Space] [SerializeField] private float heroSpawnDelay;
    [SerializeField] private float enemiesSpawnDelay;
    [SerializeField] private string nextSceneName;

    private Level _level;
    private GameObject _hero;
    private List<GameObject> _enemies = new();

    public static Action<string> OnLevelComplete;

    private void Start()
    {
        SpawnObjects();
        SpawnHeroAndEnemies();
    }

    private void SpawnObjects()
    {
        SpawnLevel();
        StartCoroutine(SpawnHeroAndEnemies());
    }

    private void SpawnLevel()
    {
        _level = Instantiate(levelPrefab);
    }

    private IEnumerator SpawnHeroAndEnemies()
    {
        yield return new WaitForSeconds(heroSpawnDelay);
        _hero = Instantiate(heroPrefab,
            levelPrefab.GetHeroPos().position +
            (Vector3.up * (heroPrefab.GetComponent<Renderer>().bounds.size.y / 2 - 0.5f)),
            Quaternion.identity);

        yield return new WaitForSeconds(enemiesSpawnDelay);
        Transform[] enemiesPos = levelPrefab.GetEnemiesPos();
        for (int i = 0; i < enemiesPos.Length; i++)
        {
            HealthComponent healthComponent;
            GameObject enemy = enemiesPrefab[Random.Range(0, enemiesPrefab.Count - 1)];
            if (enemy != null && enemy.TryGetComponent(out healthComponent))
            {
                healthComponent.death += obj => RemoveEnemiesOnDeath(obj);
            }

            GameObject newObj = Instantiate(enemy, enemiesPos[i].position + Vector3.up * 0.5f,
                enemiesPos[i].rotation);
            _enemies.Add(newObj);
        }
    }

    private void RemoveEnemiesOnDeath(GameObject go)
    {
        _enemies.Remove(go);
        if (_enemies.Count == 0)
        {
            OnLevelComplete?.Invoke(nextSceneName);
        }
    }
}