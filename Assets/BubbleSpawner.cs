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

    }

    public void SpawnNewBubble()
    {
        BubbleBlowUpController bubble = FindFirstObjectByType<BubbleBlowUpController>();
        if (bubble == null)
        {
            Instantiate(bubbleToSpawn, spawnLocation.transform.position, Quaternion.identity);


        }
    }
}
