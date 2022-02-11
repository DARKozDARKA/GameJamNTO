using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : MonoBehaviour
{
    public static AIHandler Instance { get; set; }
    private List<Enemy> _enemies;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
        Instance = this;
        _enemies = new List<Enemy>();
    }

    public void AddNewEnemy(Enemy newEnemy)
    {
        _enemies.Add(newEnemy);
    }

    public void StartGame()
    {
        foreach (var item in _enemies)
        {
            item.StartSeeking();
        }
    }
}
