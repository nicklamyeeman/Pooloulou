using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField]
    private MyGameManager gameManager;
    private Text _scoreText;
    private string baseText = "Turn:\n";

    void Awake()
    {
        _scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = baseText + gameManager.PlayerTurn().Name;
    }
}
