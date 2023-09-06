using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public static event Action<float> OnPointsGained;

    [SerializeField] private Sprite[] sprites;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AsteroidsParticle particle;

    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float size = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        particle = GetComponentInChildren<AsteroidsParticle>();
    }

    private void OnEnable()
    {
        SetUp();
    }

    private void SetUp()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0,0,Random.value * 360f);
        this.transform.localScale = Vector3.one * this.size;
        size = Random.Range(minSize, maxSize);
        rb.mass = this.size;
    }
    
    public void SetDiretion(Vector3 direction)
    {
        rb.AddForce(direction * 10);
    }

    private void CreateSplit()
    {
        Vector2 pos = this.transform.position;
        pos += Random.insideUnitCircle * 0.5f;

        Asteroid half = AsteroidPool.Instance.GetFromPool().GetComponent<Asteroid>();
        half.transform.position = pos;
        half.size = this.size * 0.5f;

        half.SetDiretion(Random.insideUnitCircle.normalized * 5);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();

        if(bullet != null)
        {
            if((this.size * 0.5f) >= this.minSize)
            {
                OnPointsGained?.Invoke(100);
                SoundManager.Instance.PlaySound("LargeExplosion");
                CreateSplit();
                CreateSplit();

            }
            else
            {
                OnPointsGained?.Invoke(50);
                SoundManager.Instance.PlaySound("SmallExplosion");
            }

            AsteroidPool.Instance.AddToPool(this.gameObject);
        }
    }


    
}
