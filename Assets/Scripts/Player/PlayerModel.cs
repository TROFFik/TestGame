public class PlayerModel
{
    private float _speed;
    private int _points;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public int Points
    {
        get { return _points; }
        set { _points += value; }
    }
}
