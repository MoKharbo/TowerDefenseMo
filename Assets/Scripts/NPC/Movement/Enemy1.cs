using System;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float movespeed = 2f;
    public static Action<float> GoldDropped;
    [SerializeField] private int HealthPoints = 3;
    [SerializeField] private float goldValue = 10f;
    private Rigidbody2D rb;
    [SerializeField] private Transform checkpoint;
    private int index = 0;
    private WaveUI waveUI;
    private LevelsManager levelsManager;

    private bool wave5 = false;
    private bool wave10 = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (waveUI == null)
        {
            waveUI = FindFirstObjectByType<WaveUI>();
        }

        if (levelsManager == null)
        {
            levelsManager = FindFirstObjectByType<LevelsManager>();
        }
    }
    void Start()
    {
        checkpoint = EnemyManager.main.checkpoints[index];
    }

    void Update()
    {
        checkpoint = EnemyManager.main.checkpoints[index];

        if (Vector2.Distance(checkpoint.transform.position, transform.position) < 0.1f)
        {
            index++;
            if (index >= EnemyManager.main.checkpoints.Length)
            {
                Destroy(gameObject);
            }
        }

        if (HealthPoints <= 0)
        {
            levelsManager.IncreaseXP(50);
            WaveSpawner.onEnemyDestroyed.Invoke();
            Destroy(gameObject);
            GoldDropped?.Invoke(goldValue);
            Debug.Log("Gold Dropped");
        }

        if (waveUI.currentWave >= 5 && !wave5)
        {
            movespeed = 3f;
            HealthPoints = 4;
            wave5 = true;
        }

        if (waveUI.currentWave >= 10 && !wave10)
        {
            movespeed = 4f;
            HealthPoints = 5;
            wave10 = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HealthPoints--;
            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate()
    {
        Vector2 direction = (checkpoint.position - transform.position).normalized;
        transform.right = checkpoint.position - transform.position;
        rb.linearVelocity = direction * movespeed;
    }
}
