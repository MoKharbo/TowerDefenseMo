using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float range = 1.5f; // Half of 3x3 area
    [SerializeField] private float spawnInterval = 1f;
    private LevelsManager levelsManager;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }


    private void Awake()
    {
        if (levelsManager == null)
        {
            levelsManager = FindFirstObjectByType<LevelsManager>();
        }
    }

    private void Update()
    {
        if (levelsManager.currentLevel >= 2)
        {
            spawnInterval = 0.5f;
        }

        if (levelsManager.currentLevel >= 5)
        {
            spawnInterval = 0.25f;
        }

        if (levelsManager.currentLevel >= 8)
        {
            spawnInterval = 0.1f;
        }

        if (levelsManager.currentLevel >= 10)
        {
            spawnInterval = 0.05f;
        }
    }

    void Spawn()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - transform.position;
            if (Mathf.Abs(diff.x) <= range && Mathf.Abs(diff.y) <= range)
            {
                float distance = diff.sqrMagnitude;
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.SetTarget(nearestEnemy, range);
            Debug.Log("Bullet spawned toward: " + nearestEnemy.name);
        }
    }
}
