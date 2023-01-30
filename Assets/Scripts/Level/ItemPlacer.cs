using UnityEngine;
using System.Threading.Tasks;

public class ItemPlacer : MonoBehaviour
{
    private int _xSize;
    private int _ySize;
    private int _countItemsOnLevel;
    private int _current—ountItemsOnLevel;
    private int _itemGenerationTime;

    private bool _itemIsBeingPlacedNow = false;
    private bool _canPlaceItem = false;

    private Pool _pool;

    public void StartPlace(int xSize, int ySize, int countItemsOnLevel, int itemGenerationTime, Pool pool)
    {
        _xSize = xSize;
        _ySize = ySize;
        _countItemsOnLevel = countItemsOnLevel;
        _itemGenerationTime = itemGenerationTime;
        _pool = pool;
        _canPlaceItem = true;

        PlaceTimer();
    }
    public void MissingItemOnMap()
    {
        _current—ountItemsOnLevel--;
        if (!_itemIsBeingPlacedNow)
        {
            PlaceTimer();
        }
    }

    private void PlaceNewItem()
    {
        Vector3 tempItemCoordinates = new Vector3(Random.Range(0, _xSize), 0, Random.Range(0, _ySize));

        var tempItem = _pool.GetFreeObject(tempItemCoordinates, transform);
        tempItem.GetComponent<Item>().ParentItemPlacer = this;

        _current—ountItemsOnLevel++;
    }

    private async void PlaceTimer()
    {

        while (_countItemsOnLevel > _current—ountItemsOnLevel)
        {
            _itemIsBeingPlacedNow = true;

            if (_canPlaceItem)
            {
                PlaceNewItem();
                await Task.Delay(_itemGenerationTime * 1000);
            }
            else
            {
                break;
            }
        }
        _itemIsBeingPlacedNow = false;
    }

    private void OnEnable()
    {
        _canPlaceItem = true;
    }

    private void OnDisable()
    {
        _canPlaceItem = false;
    }
}
