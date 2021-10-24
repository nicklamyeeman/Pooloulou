using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public string[] _playerNames;
    private List<Player> _players;
    public Text scorePlayer1;
    public Text scorePlayer2;
    private PlayersInventoryDisplay _inventories;
    private int _turn = 0;
    public int Turn => _turn;

    [SerializeField]
    private GameObject CueBall;
    private Vector3 CueBallPos;

    private bool _isFault = false;
    public bool Fault { set { _isFault = value; } }
    private bool _isPlaying = false;
    private bool _isPressed = false;
    private int _ballsDown = 0;

    private int _nbBalls = 16;

    private void Awake()
    {
        _players = MasterManager.Players;
        if (_players.Count != 2)
        {
            _players.Add(new Player("player1"));
            _players.Add(new Player("player2"));
        }

        _turn = Random.Range(0, 1);
        MasterManager.ResetGame();

        CueBallPos = CueBall.transform.position; 
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Players count: " + MasterManager.Players.Count);
        print("player 1: " + MasterManager.Players[0].Name);
        print("player 2: " + MasterManager.Players[1].Name);

        _inventories = GetComponent<PlayersInventoryDisplay>();
        setScores();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            int winner = _turn;
            endGame(_players[winner]);
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isPlaying == false)
        {
            _isPressed = true;
            CueBall.GetComponent<BallMovement>().MoveBall();
        }
        if (_isPlaying == true && AllBallStop())
        {
            if (_isFault)
                addScoreToPlayer(_turn, -5);
            if (_isFault && BallDown())
            {
                addBallToPlayer(_turn * -1 + 1, 1);
                addScoreToPlayer(_turn * -1 + 1, 10);
            }
            if (BallDown() && _isFault == false)
            {
                addBallToPlayer(_turn, _ballsDown * 1);
                addScoreToPlayer(_turn, _ballsDown * 10);
            }
            if (_ballsDown == 0 || _isFault)
                switchTurn();
            _isPlaying = false;
            _isFault = false;
        }
        if (_isPressed == true && IsWhiteBallMoving())
            _isPlaying = true;
        setInventory();
        setScores();
    }

    private bool BallDown()
    {
        GameObject white = GameObject.FindGameObjectWithTag("CueBall");
        GameObject black = GameObject.FindGameObjectWithTag("Black");
        GameObject[] yellows = GameObject.FindGameObjectsWithTag("Yellow");
        GameObject[] reds = GameObject.FindGameObjectsWithTag("Red");
        int currentNbBalls = 0;

        if (white && black)
            currentNbBalls += 2;
        currentNbBalls += yellows.Length + reds.Length;
        _ballsDown = _nbBalls - currentNbBalls;
        _nbBalls = currentNbBalls;
        if (_ballsDown != 0)
            return true;
        return false;
    }

    private bool IsWhiteBallMoving()
    {
        GameObject white = GameObject.FindGameObjectWithTag("CueBall");

        if (white.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            return true;
        return false;
    }

    private bool AllBallStop()
    {
        GameObject white = GameObject.FindGameObjectWithTag("CueBall");
        GameObject black = GameObject.FindGameObjectWithTag("Black");

        if (white.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            return false;
        if (black.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            return false;

        if (HasBallStoped("Red") == false)
            return false;
        if (HasBallStoped("Yellow") == false)
            return false;
        print("C ARRETE LOL");
        return true;
    }

    private bool HasBallStoped(string tag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject elem in objs)
        {
            if (elem.GetComponent<Rigidbody>().velocity.magnitude > 0.5f)
            {
                return false;
            }
        }
        return true;
    }

    public void respawnBall()
    {
        CueBall.transform.position = CueBallPos;
    }

    private void setScores()
    {
        scorePlayer1.text = _players[0].Name + " " +
            _players[0].Score + " pts";
        scorePlayer2.text = _players[1].Score + " pts " +
            _players[1].Name;
    }

    private void setInventory()
    {
        Dictionary<int, int> items = new Dictionary<int, int>();
        items.Add(0, _players[0].Balls);
        items.Add(1, _players[1].Balls);
        _inventories.addItems(items);
        _inventories.ChangeColor(0, _players[0].BallType);
        _inventories.ChangeColor(1, _players[1].BallType);
    }

    public void endGame(Player winner)
    {
        MasterManager.Winner = winner;
        SceneManager.LoadScene("FinalScores");
    }

    public void addScoreToPlayer(int index, int score) => _players[index].addScore(score);

    public void addBallToPlayer(int index, int nb) => _players[index].Balls = nb;

    public void setBallType(string type, int index) => _players[index].BallType = type;

    public void switchTurn() => _turn = _turn * -1 + 1;

    public Player PlayerTurn() => _players[_turn];
    public Player PlayerWaiting() => _players[_turn * -1 + 1];
}
