using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;

    [SerializeField] private int spawnAmmount;

    [SerializeField] private float spawnDistance;

    [SerializeField] private float trajectoryVariance;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < spawnAmmount; i++)
        {
            Vector3 spawnDir = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDir;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance,Vector3.forward);

            Asteroid asteroid = AsteroidPool.Instance.GetFromPool().GetComponent<Asteroid>();
            
            asteroid.transform.position = spawnPoint;
            asteroid.transform.rotation = rotation;

            asteroid.SetDiretion(rotation * -spawnDir);
        }
    }
}
