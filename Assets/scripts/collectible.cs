using UnityEngine;

public class collectible : MonoBehaviour
{
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if PLAYER touched the collectible
        if (collision.CompareTag("Player"))
        {
            logic.addScore(1);

            Debug.Log("Collected!");

            // Destroy THIS collectible object
            Destroy(gameObject);
        }
    }
}