using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private float currentPoint;
    public float GetCurrentPoint
    {
        get { return  currentPoint; }
    }

    private void OnEnable()
    {
        Asteroid.OnPointsGained += AddPoints;
    }

    private void OnDisable()
    {
        Asteroid.OnPointsGained -= AddPoints;
    }

    private void AddPoints(float pointsToAdd)
    {
        currentPoint += pointsToAdd;
        text.text = currentPoint.ToString();
    }


}
