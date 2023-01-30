using UnityEngine;

[RequireComponent(typeof(PlaneCreator), typeof(ItemPlacer))]
public class LevelManager : MonoBehaviour
{
    [Tooltip("X size of generated surface and place of spawning items")]
    [SerializeField] private int _levelXSize;

    [Tooltip("Y size of generated surface and place of spawning items")]
    [SerializeField] private int _levelYSize;

    [Tooltip("The number of items that will be on level")]
    [SerializeField] private int _countItemsOnLevel;

    [Tooltip("Time that should elapse between item generations (in seconds)")]
    [SerializeField] private int _itemGenerationTime;

    [Tooltip("Items object pool for this level")]
    [SerializeField] private Pool _pool;

    private PlaneCreator _planeCreator;
    private ItemPlacer _itemPlacer;

    private void Start()
    {
        GetLevelComponents();
        CreateLevel();
    }

    private void GetLevelComponents()
    {
        _planeCreator = GetComponent<PlaneCreator>();
        _itemPlacer = GetComponent<ItemPlacer>();
    }

    private void CreateLevel()
    {
        _planeCreator.StartCreate(_levelXSize, _levelYSize);
        _itemPlacer.StartPlace(_levelXSize, _levelYSize, _countItemsOnLevel, _itemGenerationTime, _pool);
    }
}
