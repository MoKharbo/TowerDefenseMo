using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnTower : MonoBehaviour
{
    [SerializeField] GameObject[] targetObjects;
    [SerializeField] private GameObject menu;
    private GoldUI goldUI;

    enum State { aan, uit }
    State myEnum = State.aan;
    
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
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
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.zero);

            if (hit.collider != null && myEnum == State.aan && goldUI.goldAmount >= 50)
            {
                foreach (GameObject target in targetObjects)
                {
                    if (hit.collider.gameObject == target)
                    {
                        Instantiate(menu,mousePos, Quaternion.identity);
                        spriteRenderer.enabled = false;
                        myEnum = State.uit;

                        break;
                    }
                }
            }
        }
    }
}