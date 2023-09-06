using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform spawnProjectile;

    private PlayerInput playerInput;

    private float timer;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if(playerInput.GetShooting && timer >= 0.5f)
        {
            Shoot();
            timer = 0;
        }
    }

    private void Shoot()
    {
        GameObject bullet = BulletPool.Instance.GetFromPool();
        bullet.transform.rotation = transform.rotation;
        bullet.transform.position = spawnProjectile.transform.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 5, ForceMode2D.Impulse);
        SoundManager.Instance.PlaySound("Shoot");

    }



}
