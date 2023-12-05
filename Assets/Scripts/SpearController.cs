using UnityEngine;

public class SpearController : MonoBehaviour
{
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 direction = mouseWorldPosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}