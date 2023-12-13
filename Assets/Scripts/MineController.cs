using UnityEngine;

public class MineController : MonoBehaviour
{
    public GameObject explosion;
    private SceneTransition sceneTransition;

    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            sceneTransition.FadeToScene("DeathScreen");
        }
    }
}