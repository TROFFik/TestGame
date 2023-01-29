using UnityEngine;

[RequireComponent(typeof(PlaneCreator), typeof(ItemPlacer))]
public class LevelManager : MonoBehaviour
{
    [Tooltip("X size of generated surface and place of spawning items")]
    [SerializeField] private int _levelXSize;

    [Tooltip("Y size of generated surface and place of spawning items")]
    [SerializeField] private int _levelYSize;

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
    }
}
