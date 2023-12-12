using UnityEngine;

public class SpearController : MonoBehaviour
{
    private SpearShooter shooter;

    void Start()
    {
        shooter = FindObjectOfType<SpearShooter>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Spear"))
        {
            shooter.CollectSpear();
            Destroy(gameObject);
        }
    }
}