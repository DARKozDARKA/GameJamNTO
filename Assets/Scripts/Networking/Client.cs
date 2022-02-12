using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Client : NetworkBehaviour
{
    public static Client Instance { get; private set; }
    private List<PlayerBehaviour> _players;
    public List<PlayerBehaviour> players => _players;
    private PlayerBehaviour _clientPlayer;
    public PlayerBehaviour clientPlayer => _clientPlayer;

    private void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;
    }


    public void SetPlayers(List<PlayerBehaviour> players)
    {
        _players = players;
    }

    private void OnDestroy()
    {
        if (Instance is null) return;
        Destroy(Instance.gameObject);
        Instance = null;
    }


    public void SetOffClient()
    {
        Destroy(gameObject);
    }


    public void SetPlayer(PlayerBehaviour player)
    {
        _clientPlayer = player;
    }

    private void OnDisconnectedFromServer()
    {
        print("hey");
    }

}
