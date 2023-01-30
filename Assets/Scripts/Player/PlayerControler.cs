using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerView))]
public class PlayerControler : MonoBehaviour
{
    [Tooltip("Player move speed")]
    [SerializeField] private float _maxSpeed;

    private float _allDistance;

    private PlayerModel _playerModel;
    private PlayerView _playerView;

    private List <Vector3> _targetÑoordinates = new List <Vector3>();

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
            InputÑalculations();
        }

        MoveÑalculations();
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

    private void InputÑalculations()
    {
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var hitPlayer = hit.collider.gameObject.GetComponent<PlayerControler>();
            if (hitPlayer != null)
            {
                _targetÑoordinates.Clear();
                _startPoint = transform.position;
                _allDistance = 0;
            }
            else
            {
                _targetÑoordinates.Add( new Vector3(hit.point.x, 0, hit.point.z));
            }   
        }
    }

    private void MoveÑalculations()
    {
        if (_targetÑoordinates.Count > 0)
        {
            float distance = Vector3.Distance(transform.position, _targetÑoordinates[0]);

            if (distance > 0)
            {
                _allDistance = _allDistance == 0 ? Vector3.Distance(_startPoint, _targetÑoordinates[0]): _allDistance;
                float distanceCoefficient = Vector3.Distance(transform.position, _startPoint) / _allDistance;
                distanceCoefficient = Mathf.Clamp(distanceCoefficient, 0.01f, 0.99f); //Restricted the sine to avoid the Achilles paradox
                float speed = _playerModel.MaxSpeed * Mathf.Sin(distanceCoefficient * Mathf.PI);

                transform.position = Vector3.MoveTowards(transform.position, _targetÑoordinates[0], speed);

                distance = Vector3.Distance(transform.position, _lastPotition);
                _lastPotition = transform.position;
                _playerModel.Distance = distance;
                _playerView.SetDistance(_playerModel.Distance);
            }
            else
            {
                _targetÑoordinates.Remove(_targetÑoordinates[0]);
                if (_targetÑoordinates.Count > 0)
                {
                    _startPoint = transform.position;
                    _allDistance = Vector3.Distance(_startPoint, _targetÑoordinates[0]);
                }
            }
        }       
    }

    private void OnDisable()
    {
        _playerModel.SaveData();
    }
}
