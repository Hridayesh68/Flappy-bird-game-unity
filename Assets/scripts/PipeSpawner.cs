using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 0.5f;
    public float heightoffset = 2f;
    private float timer = 0;

    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;
float maxDifficultyLimit=0.8f;
spawnRate -=0.001f*Time.deltaTime;
spawnRate=Mathf.Max(spawnRate,maxDifficultyLimit);

        if (timer >= spawnRate)
        {
            spawnPipe();
            timer = 0;
        }
        
    }

    void spawnPipe()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;

        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            Random.Range(lowestpoint, highestpoint),
            transform.position.z
        );

        Instantiate(pipe, spawnPosition, transform.rotation);
    }
}