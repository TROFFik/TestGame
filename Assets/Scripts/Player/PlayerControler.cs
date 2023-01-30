using UnityEngine;

[RequireComponent(typeof(PlayerView))]
public class PlayerControler : MonoBehaviour
{
    [Tooltip("Player move speed")]
    [SerializeField] private float _speed; 

    private PlayerModel _playerModel;
    private PlayerView _playerView;

    private Vector3 _target—oordinates;
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

        transform.position = Vector3.MoveTowards(transform.position, _target—oordinates, _playerModel.Speed);
    }

    public void GetPoints()
    {
        _playerModel.Points = 1;
        Debug.Log(_playerModel.Points);
    }

    private void GetPlayerComponents()
    {
        _playerModel = new PlayerModel();
        _playerView = GetComponent<PlayerView>();

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
