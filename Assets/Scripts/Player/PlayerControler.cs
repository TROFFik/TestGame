using UnityEngine;

[RequireComponent(typeof(PlayerView))]
public class PlayerControler : MonoBehaviour
{
    [Tooltip("Player move speed")]
    [SerializeField] private float _speed; 

    private PlayerModel _playerModel;
    private PlayerView _playerView;

    private Vector3 _target—oordinates;
    private Vector3 lastPotition;
    private void Start()
    {
        GetPlayerComponents();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Input—alculations();
        }

        float distance = Vector3.Distance(transform.position, _target—oordinates);
        if (distance > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target—oordinates, _playerModel.Speed);

            distance = Vector3.Distance(transform.position, lastPotition);
            lastPotition = transform.position;
            _playerModel.Distance = Mathf.Abs(distance);
            _playerView.SetDistance(_playerModel.Distance);
        }
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

        _playerView.SetPoints(_playerModel.Points);
        _playerView.SetDistance(_playerModel.Distance);
        _playerModel.Speed = _speed;
    }

    private void Input—alculations()
    {
        
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var hitPlayer = hit.collider.gameObject.GetComponent<PlayerControler>();
            if (hitPlayer != null)
            {
                _target—oordinates = transform.position;
            }
            else
            _target—oordinates = new Vector3(hit.point.x, 0, hit.point.z);
        }
    }
}
