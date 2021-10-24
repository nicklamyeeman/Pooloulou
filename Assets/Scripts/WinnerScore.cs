using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScore : MonoBehaviour
{
    private Text _winnerScore;
    private string _baseText = "Score: ";

    // Start is called before the first frame update
    void Start()
    {
        _winnerScore = GetComponent<Text>();
        print(MasterManager.Players.Count + " " + MasterManager.Winner.Score);
        _winnerScore.text = _baseText + MasterManager.Winner.Score;
    }

}
