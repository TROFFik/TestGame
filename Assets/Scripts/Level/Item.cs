using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemPlacer _parentItemPlacer;

    public ItemPlacer ParentItemPlacer
    {
        set { _parentItemPlacer = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tempPlayer = collision.gameObject.GetComponent<PlayerControler>();
        if (tempPlayer != null)
        {
            tempPlayer.GetPoints();
            _parentItemPlacer.MissingItemOnMap();
            Destroy(gameObject);
        }
    }
}
