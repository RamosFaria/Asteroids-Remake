using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem partSystem;

    private Transform parent;

    private void Awake()
    {
        parent = transform.GetComponentInParent<Transform>();
    }

    public void ActivateParticle()
    {

        partSystem.Play();
        
        Invoke(nameof(ReturnToParent),1f);
    }

    private void ReturnToParent()
    {
        this.transform.parent = this.parent;
    }

}
