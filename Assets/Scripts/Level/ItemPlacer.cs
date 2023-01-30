using System.Collections;
using System.Collections.Generic;
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

    private GameObject _itemPrefab;

    public void StartPlace(int xSize, int ySize, int countItemsOnLevel, int itemGenerationTime, GameObject itemPrefab)
    {
        _xSize = xSize;
        _ySize = ySize;
        _countItemsOnLevel = countItemsOnLevel;
        _itemGenerationTime = itemGenerationTime;
        _itemPrefab = itemPrefab;
        _canPlaceItem = true;

        PlaceTimer();
    }

    private void PlaceNewItem()
    {
        var tempItem = Instantiate(_itemPrefab);
        Vector3 tempItemCoordinates = new Vector3(Random.Range(0, _xSize), 0, Random.Range(0, _ySize));

        tempItem.transform.localPosition = tempItemCoordinates;

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
