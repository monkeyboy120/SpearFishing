using System;
using UnityEngine;

public class SpearShooter : MonoBehaviour
{
    public GameObject spearPrefab;
    public float shootingForce = 500f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootSpear();
        }
    }

    void ShootSpear()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 x = mouseWorldPosition - transform.position;

        float angle = Mathf.Atan2(x.y, x.x) * Mathf.Rad2Deg - 45;

        GameObject spear = Instantiate(spearPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        rb.AddForce(direction * shootingForce);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Spear"))
        {
            Destroy(other.gameObject);
        }
    }
}