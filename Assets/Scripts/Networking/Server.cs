using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;

public class Server : NetworkBehaviour
{
    public static Server Instance { get; private set; }
    private int _currentTeam = 0;
    private Dictionary<uint, PlayerBehaviour> _players;

    private void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
        _players = new Dictionary<uint, PlayerBehaviour>();
    }

    private void OnDestroy()
    {
        Destroy(Instance.gameObject);
        Instance = null;
    }


    public void SetNewPlayer(PlayerBehaviour player, uint id)
    {
        _players.Add(id, player);

        var _playerKeys = _players.Values.ToArray();
        foreach (var item in _playerKeys)
        {
            item.SetPlayers(_playerKeys);
        }

    }

    public void DeletePlayer(uint id)
    {
        _players.Remove(id);
    }





}
