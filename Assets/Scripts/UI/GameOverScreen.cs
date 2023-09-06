using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI currentPointsText;
    [SerializeField] private PointsHandler pointsHandler;

    private void OnEnable()
    {
        HealthHandler.GameOver += SetGameOverActive;
    }

    private void OnDisable()
    {
        HealthHandler.GameOver -= SetGameOverActive;
    }
    
    private void SetGameOverActive()
    {
        gameOverScreen.SetActive(true);
        currentPointsText.text = (pointsHandler.GetCurrentPoint).ToString();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
