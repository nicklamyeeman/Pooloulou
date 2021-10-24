using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singleton/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    private List<Player> players = new List<Player>();
    public static List<Player> Players { get { return Instance.players; } set { Instance.players = value; } }
    private Player winner = new Player("Random");
    public static Player Winner { get { return Instance.winner; } set { Instance.winner = value; } }

    public static void ResetGame()
    {
        foreach(Player elem in Instance.players)
        {
            elem.Reset();
        }
    }
}
