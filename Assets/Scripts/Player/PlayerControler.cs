using UnityEngine;

[RequireComponent(typeof(PlayerView))]
public class PlayerControler : MonoBehaviour
{
    [Tooltip("Player move speed")]
    [SerializeField] private float _maxSpeed;

    private float _allDistance;

    private PlayerModel _playerModel;
    private PlayerView _playerView;

    private Vector3 _target�oordinates;
    private Vector3 _lastPotition;
    private Vector3 _startPoint;
    private void Start()
    {
        GetPlayerComponents();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Input�alculations();
        }

        Move�alculations();
    }

    public void GetPoints()
    {
        _playerModel.Points = 1;
        _playerView.SetPoints(_playerModel.Points);
    }

    private void GetPlayerComponents()
    {
        _playerModel = new PlayerModel();
        _playerView = GetComponent<PlayerView>();

        _playerModel.MaxSpeed = _maxSpeed;

        _playerModel.LoadData();
        _playerView.SetPoints(_playerModel.Points);
        _playerView.SetDistance(_playerModel.Distance);
    }

    private void Input�alculations()
    {
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var hitPlayer = hit.collider.gameObject.GetComponent<PlayerControler>();
            if (hitPlayer != null)
            {
                _target�oordinates = transform.position;
            }
            else
            {
                _target�oordinates = new Vector3(hit.point.x, 0, hit.point.z);

                _startPoint = transform.position;
                _allDistance = Vector3.Distance(_startPoint, _target�oordinates);
            }   
        }
    }

    private void Move�alculations()
    {
        float distance = Vector3.Distance(transform.position, _target�oordinates);

        if (distance > 0)
        {
            float distanceCoefficient = Vector3.Distance(transform.position, _startPoint) / _allDistance;
            distanceCoefficient = Mathf.Clamp(distanceCoefficient, 0.01f, 0.99f);
            float speed = _playerModel.MaxSpeed * Mathf.Sin(distanceCoefficient * Mathf.PI);

            transform.position = Vector3.MoveTowards(transform.position, _target�oordinates, speed);

            distance = Vector3.Distance(transform.position, _lastPotition);
            _lastPotition = transform.position;
            _playerModel.Distance = distance;
            _playerView.SetDistance(_playerModel.Distance);
        }
    }

    private void OnDisable()
    {
        _playerModel.SaveData();
    }
}
