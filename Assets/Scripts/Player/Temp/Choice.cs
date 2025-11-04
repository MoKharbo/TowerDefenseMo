using UnityEngine;

public class Choice : MonoBehaviour
{
    [SerializeField] private GameObject SquarePrefab;
    [SerializeField] private GameObject CirclePrefab;
    [SerializeField] private GameObject TrianglePrefab;
    [SerializeField] private GoldUI goldUI;

    void Awake()
    {
        if (goldUI == null)
        {
            goldUI = FindFirstObjectByType<GoldUI>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject prefabToInstantiate = null;

                if (hit.collider.CompareTag("Square"))
                {
                    prefabToInstantiate = SquarePrefab;
                   
                } 
                else if (hit.collider.CompareTag("Circle") && goldUI.goldAmount >= 50)
                {
                    prefabToInstantiate = CirclePrefab;
                    goldUI.goldAmount -= 50;
                    goldUI.goldText.text = "Gold: " + goldUI.goldAmount;
                }
                else if (hit.collider.CompareTag("Triangle"))
                    prefabToInstantiate = TrianglePrefab;

                if (prefabToInstantiate != null)
                {
                    Instantiate(prefabToInstantiate, hit.collider.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    GameObject menu = GameObject.FindWithTag("Menu");
                    if (menu != null)
                        Destroy(menu);

                    
                }
            }
        }
    }
}
