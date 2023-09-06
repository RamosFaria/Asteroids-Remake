using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{

    public static event Action ActivatePlayer;
    public static event Action GameOver;

    private int maxLives = 3;
    private int currentLives;

    [SerializeField] private Image[] livesImages;

    private void Awake()
    {
        currentLives = maxLives;
    }

    private void OnEnable()
    {
        PlayerMovement.OnTakeDamage += Damage;
    }

    private void OnDisable()
    {
        PlayerMovement.OnTakeDamage -= Damage;
    }
    
    private void Damage()
    {
        currentLives--;
        HealthUI(currentLives);
        if ( currentLives <= 0 )
        {
            GameOver?.Invoke();
        }
        else
        {
            StartCoroutine(WaitTime());
        }
    }

    private void HealthUI(int lives)
    {
        foreach(Image image in livesImages)
        {
            image.gameObject.SetActive(false);
        }

        for(int i = 0; i < lives; i++)
        {
            livesImages[i].gameObject.SetActive(true);
        }

    }

    private IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(1f);

        ActivatePlayer?.Invoke();
    }

}
