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
  if ((Input.GetKeyDown(KeyCode.Space) ||
     Input.GetMouseButtonDown(0) ||
     (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
    && birdisalive && Time.timeScale > 0)
{
    myrigidbody.linearVelocity = Vector2.up * flapstrength;
}

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