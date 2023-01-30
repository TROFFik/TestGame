using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private Transform _poolTransform;
    public Transform PoolTransform
    {
        set { _poolTransform = value; }
    }

    public void RetunToPool()
    {
        gameObject.transform.SetParent(_poolTransform);
        gameObject.SetActive(false);
    }
}
