using UnityEngine;

public class Fish : MonoBehaviour
{
    public enum FishType
    {
        SmallFish,
        MediumFish,
        LargeFish
    }

    public FishType typeOfFish;
    public int score;
    public GameObject deathEffect; // Add death effect prefab

    public float speed = 0.3f;
    private float turnTimer;
    public float timeTrigger;

    private Rigidbody2D myRigidbody;

    void Start()
    {
        // Score setup
        switch (typeOfFish)
        {
            case FishType.SmallFish:
                score = 10;
                break;
            case FishType.MediumFish:
                score = 20;
                break;
            case FishType.LargeFish:
                score = 30;
                break;
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        turnTimer = Random.Range(1, 5);
        timeTrigger = Random.Range(1, 5);
    }

    void Update()
    {
        myRigidbody.velocity = new Vector3(transform.localScale.x * speed, myRigidbody.velocity.y, 0f);

        turnTimer += Time.deltaTime;
        if (turnTimer >= timeTrigger)
        {
            TurnAround();
            turnTimer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spear"))
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            FindObjectOfType<MenuManager>().AddScore(this.score);
            Destroy(gameObject);
        }
    }

    void TurnAround()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
    }
}