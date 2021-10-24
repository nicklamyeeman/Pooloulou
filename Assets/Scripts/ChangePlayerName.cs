using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerName : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;

    public void OnEndChange_PlayerName(string name)
    {
        print("CA PASSE");
        print("Players count: " + MasterManager.Players.Count);
        List<Player> players = MasterManager.Players;

        players[playerIndex] = new Player(name);

        MasterManager.Players = players;
        print("Players count: " + MasterManager.Players.Count);

    }
}
