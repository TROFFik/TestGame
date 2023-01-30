using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject _poolObject;
    [SerializeField] private Transform _container;
    [SerializeField] private int _minObjectCount;
    [SerializeField] private int _maxObjectCount;
    [SerializeField] private bool _createObjectsAutomatically;

    private List<PoolObject> _poolObjectsList;

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _poolObjectsList = new List<PoolObject>(_minObjectCount);

        for (int i = 0; i < _minObjectCount; i++)
        {
            CreateObject(false);
        }
    }
    
    private PoolObject CreateObject(bool defaultActive)
    {
        var createdObject = Instantiate(_poolObject, _container);
        createdObject.gameObject.SetActive(defaultActive);

        _poolObjectsList.Add(createdObject);

        var itemCreatedObject = createdObject.GetComponent<Item>();
        if (itemCreatedObject != null)
        {
            itemCreatedObject.PoolObject = createdObject;
        }

        return createdObject;
    }

    private bool TryGetObject(out PoolObject poolObject)
    {
        foreach (var item in _poolObjectsList)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                poolObject = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        poolObject = null;
        return false;
    }

    public PoolObject GetFreeObject()
    {
        if (TryGetObject(out PoolObject poolObject))
        {
            return poolObject;
        }

        if (_createObjectsAutomatically)
        {
            return CreateObject(false);
        }

        if (_poolObjectsList.Count < _maxObjectCount)
        {
            return CreateObject(false);
        }

        Debug.LogError("Pool is Full!");
        return null;
    }

    public PoolObject GetFreeObject(Vector3 objectPotition)
    {
        PoolObject poolObject = GetFreeObject();
        poolObject.transform.position = objectPotition;
        poolObject.gameObject.SetActive(true);
        return poolObject;
    }
    public PoolObject GetFreeObject(Vector3 objectPotition, Transform parent)
    {
        PoolObject poolObject = GetFreeObject();
        poolObject.transform.position = objectPotition;
        poolObject.transform.SetParent(parent);
        poolObject.gameObject.SetActive(true);
        poolObject.PoolTransform = gameObject.transform;
        return poolObject;
    }
}
