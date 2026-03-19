using UnityEngine;

public class bird_script : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapstrength;
    public LogicScript logic;
    public bool birdisalive = true;

    [SerializeField] AudioSource Flapsound;

    // Dynamic bounds instead of fixed values
    private float upperLimit;
    private float lowerLimit;

    void Start()
    {
        gameObject.name = "bob bird";
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();

        UpdateBounds();
        PositionBird();
    }

    void Update()
    {
        HandleInput();
        UpdateBounds();
        PositionBird();
        CheckBounds();
    }

    void HandleInput()
    {
        if ((Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            && birdisalive && Time.timeScale > 0)
        {
            myrigidbody.linearVelocity = Vector2.up * flapstrength;
            Flapsound.Play();
        }
    }

    void UpdateBounds()
    {
        float camHeight = Camera.main.orthographicSize;
        upperLimit = camHeight;
        lowerLimit = -camHeight;
    }

    void PositionBird()
    {
        float leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        transform.position = new Vector3(leftEdge + 1.5f, transform.position.y, 0);
    }

    void CheckBounds()
    {
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
        myrigidbody.simulated = false;
    }
}