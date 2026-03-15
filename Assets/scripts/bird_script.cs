using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapstrength;
    public LogicScript logic;
    public bool birdisalive = true;
    
    // Set these based on your camera view (usually around 10 and -10)
    public float upperLimit = 12f;
    public float lowerLimit = -12f;

    void Start()
    {
        gameObject.name = "bob bird";
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        // 1. Flap logic (Check Time.timeScale to prevent flapping while paused)
        if (Input.GetKeyDown(KeyCode.Space) && birdisalive && Time.timeScale > 0)
        {
            myrigidbody.linearVelocity = Vector2.up * flapstrength;
        }

        // 2. Check if bird is off-screen
        if (transform.position.y > upperLimit || transform.position.y < lowerLimit)
        {
            if (birdisalive) 
            {
                Die();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        logic.gameOver();
        birdisalive = false;
        // Optional: stop the bird from moving/rotating more
        myrigidbody.simulated = false; 
    }
}