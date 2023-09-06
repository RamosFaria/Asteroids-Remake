using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private Transform player;

    private void Awake()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void OnEnable()
    {
        HealthHandler.ActivatePlayer += Respawn;
    }

    private void OnDisable()
    {
        HealthHandler.ActivatePlayer -= Respawn;
    }

    private void Respawn()
    {
        player.position = Vector3.zero;
        player.gameObject.SetActive(true);
    }
}
