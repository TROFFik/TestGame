using UnityEngine;
using TMPro;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textPoints;
    [SerializeField] private TextMeshProUGUI _textDistance;

    public void SetPoints(int points)
    {
        _textPoints.text = "Points: " + points;
    }

    public void SetDistance(float distance)
    {
        _textDistance.text = "Distance: " + distance;
    }
}
