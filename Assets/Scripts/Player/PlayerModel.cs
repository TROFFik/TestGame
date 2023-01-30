public class PlayerModel
{
    private float _speed;
    private float _distance;
    private int _points;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public float Distance
    {
        get { return _distance; }
        set { _distance += value; }
    }

    public int Points
    {
        get { return _points; }
        set { _points += value; }
    }

    public void LoadData()
    {
        _distance = MemoryController.LoadData("Distance");
        _points = (int)MemoryController.LoadData("Points");
    }

    public void SaveData()
    {
        MemoryController.SaveData("Distance", _distance);
        MemoryController.SaveData("Points", _points);
    }
}
