using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIHandler : MonoBehaviour
{
    [SerializeField] private List<string> _names;
    public static AIHandler Instance { get; set; }
    private List<Enemy> _enemies;
    [SerializeField] private Transform _exit;
    public Transform exit => _exit;

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
    }

    public void StartGame()
    {
        foreach (var item in _enemies)
        {
            item.StartSeeking();
        }
    }

    public struct Dude
    {
        public string name;
        public int moneySpend;
        public Dude(string newName, int newMoney)
        {
            name = newName;
            moneySpend = newMoney;
        }
    }

    public void PrintAllEnemiesSpendMoney()
    {
        var newDictionary = new List<Dude>();
        foreach (var item in _enemies)
        {
            newDictionary.Add(new Dude(item.name, item.moneyController.spendedMoney));
        }
        newDictionary = newDictionary.OrderBy(pair => pair.moneySpend).ToList();
        newDictionary.Reverse();
        foreach (var item in newDictionary)
        {
            print(item.name + ": " + item.moneySpend);
        }

    }
}
