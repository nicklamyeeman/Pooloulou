using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    private void Awake()
    {
        List<Player> initPlayers = new List<Player>();

        initPlayers.Add(new Player("player1"));
        initPlayers.Add(new Player("player2"));
        MasterManager.Players = initPlayers;
    }

    public void OnClick_ValidateInputs(string sceneName)
    {
        print("Players count: " + MasterManager.Players.Count);
        print("player 1: " + MasterManager.Players[0].Name);
        print("player 2: " + MasterManager.Players[1].Name);
        SceneManager.LoadScene(sceneName);
    }
}
