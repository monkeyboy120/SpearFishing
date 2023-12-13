using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpearShooter : MonoBehaviour
{
    public GameObject spearPrefab;
    public float shootingForce = 500f;
    public int maxSpears = 5;
    private int currentSpears;
    public TextMeshProUGUI spearCountText;

    void Start()
    {
        currentSpears = maxSpears;
        UpdateSpearCountText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentSpears > 0 && !PauseMenuScript.isPaused)
        {
            ShootSpearTowardsCursor();
            currentSpears--;
            UpdateSpearCountText();
        }
    }

    void ShootSpearTowardsCursor()
    {
        Vector2 shootingDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject spear = Instantiate(spearPrefab, transform.position, Quaternion.identity);
        Rigidbody2D spearRigidbody = spear.GetComponent<Rigidbody2D>();
        spearRigidbody.velocity = shootingDirection * shootingForce;
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        spear.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void CollectSpear()
    {
        currentSpears = Mathf.Min(currentSpears + 1, maxSpears);
        UpdateSpearCountText();
    }

    void UpdateSpearCountText()
    {
        spearCountText.text = "Spears: " + currentSpears;
    }
}