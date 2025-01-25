using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bubbleToSpawn;
    public Transform spawnLocation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnNewBubble();
        }
    }

    void SpawnNewBubble()
    {
        Instantiate(bubbleToSpawn, spawnLocation.transform.position, Quaternion.identity);
    }
}
