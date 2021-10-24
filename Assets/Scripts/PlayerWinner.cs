using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWinner : MonoBehaviour
{
    private Text _winnerText;
    private string baseText = "Winner: ";

    // Start is called before the first frame update
    void Start()
    {
        _winnerText = GetComponent<Text>();
        _winnerText.text = baseText + MasterManager.Winner.Name;
    }
}
