using UnityEngine;

public class SpawnBubble : MonoBehaviour
{
    public bool doesBubbleExist = false;
    public GameObject BubblePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!doesBubbleExist) {
            Instantiate(BubblePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            doesBubbleExist = true;
        }
    }
}
