using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Item : MonoBehaviour
{
    private ItemPlacer _parentItemPlacer;

    private PoolObject _poolObject;
    public ItemPlacer ParentItemPlacer
    {
        set { _parentItemPlacer = value; }
    }

    public PoolObject PoolObject
    {
        set { _poolObject = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tempPlayer = collision.gameObject.GetComponent<PlayerControler>();
        if (tempPlayer != null)
        {
            tempPlayer.GetPoints();
            _parentItemPlacer.MissingItemOnMap();
            _poolObject.RetunToPool();
        }
    }
}
