using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    private Queue<GameObject> availableAsteroid = new Queue<GameObject>();

    public static AsteroidPool Instance { get; private set; }

    [SerializeField] private GameObject asteroidPrefab;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < 15; i++)
        {
            GameObject bullets = Instantiate(asteroidPrefab, transform.position, Quaternion.identity) as GameObject;
            bullets.SetActive(false);
            bullets.transform.SetParent(transform);
        }

    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            AddToPool(transform.GetChild(i).gameObject);
        }
    }

    public GameObject GetFromPool()
    {
        var instance = availableAsteroid.Dequeue();
        instance.SetActive(true);
        return instance;

    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableAsteroid.Enqueue(instance);
    }
}
