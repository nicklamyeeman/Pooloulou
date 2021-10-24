public class Player
{
    // Variables
    private string _name;
    private string _ballType;
    private int _score = 0;
    private int _balls = 0;

    // Constructor
    public Player(string name)
    {
        _name = name;
        _ballType = "none";
    }

    // getters, setters
    public int Score
    {
        get { return _score; }
    }

    public string Name {
        get { return _name; }
    }

    public int Balls
    {
        get { return _balls; }
        set { _balls += value; }
    }

    public string BallType { get { return _ballType; } set { _ballType = value; } }

    public void addScore(int points)
    {
        _score += points;
    }

    public void Reset()
    {
        _score = 0;
        _balls = 0;
    }
}
