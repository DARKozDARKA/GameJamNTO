using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHandler : MonoBehaviour
{
    [SerializeField] private List<string> _names;
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
        if (_names.Count == 0)
        {
            newEnemy.SetName("dude");
            return;
        }
        var newNameIndex = Random.Range(0, _names.Count);
        newEnemy.SetName(_names[newNameIndex]);
        _names.RemoveAt(newNameIndex);
    }

    public void StartGame()
    {
        foreach (var item in _enemies)
        {
            item.StartSeeking();
        }
    }

    public void PrintAllEnemiesSpendMoney()
    {
        foreach (var item in _enemies)
        {
            print(item.name + ": " + item.moneyController.spendedMoney);
        }
    }
}
