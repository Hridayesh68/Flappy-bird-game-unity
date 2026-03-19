using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;

    public float spawnRate = 2f;
    private float timer = 0;

    public float heightoffset = 3f;
    public float minHeightOffset = 1.5f;

    // 🔥 Distance settings
    public float spawnDistanceFromBird = 10f; // how far ahead of bird
    public float minPipeDistance = 6f;        // gap between pipes

    private float lastPipeX = float.MinValue;

    private GameObject bird;

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player");
        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        AdjustDifficulty();

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void AdjustDifficulty()
    {
        spawnRate -= 0.05f * Time.deltaTime;
        spawnRate = Mathf.Clamp(spawnRate, 1f, 3f);

        heightoffset -= 0.2f * Time.deltaTime;
        heightoffset = Mathf.Max(heightoffset, minHeightOffset);
    }

    void SpawnPipe()
    {
        float camHeight = Camera.main.orthographicSize;

        float birdX = bird.transform.position.x;

        // 🔥 Base spawn always in front of bird
        float baseSpawnX = birdX + spawnDistanceFromBird;

        // 🔥 Ensure spacing from last pipe
        float spawnX = Mathf.Max(baseSpawnX, lastPipeX + minPipeDistance);

        float minY = -camHeight + heightoffset;
        float maxY = camHeight - heightoffset;

        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        Instantiate(pipe, spawnPosition, Quaternion.identity);

        lastPipeX = spawnX;
    }
}