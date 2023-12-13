using UnityEngine;

public class SpearController : MonoBehaviour
{
    public float checkRadius = 0.001f;
    public LayerMask playerLayer;
    private SpearShooter shooter;
    private bool canBeCollected = false;

    void Start()
    {
        shooter = FindObjectOfType<SpearShooter>();
        Invoke("EnableCollection", 0.5f); // Delay before the spear can be collected
    }

    void Update()
    {
        if (canBeCollected)
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
            if (playerCollider != null)
            {
                HandlePlayerCollision(playerCollider.gameObject);
            }
        }
    }

    private void HandlePlayerCollision(GameObject player)
    {
        if (player.CompareTag("Player"))
        {
            shooter.CollectSpear();
            Destroy(gameObject);
        }
    }

    private void EnableCollection()
    {
        canBeCollected = true;
    }
}