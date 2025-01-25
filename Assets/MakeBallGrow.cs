using UnityEngine;

public class MakeBallGrow : MonoBehaviour
{
    public float maxSize = 2f;
    public float growSize = .01f;
    public GameObject bubblePrefab;
    public GameObject BubbleSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentSize = GetComponent<SpriteRenderer>().bounds.size.x;
        if (currentSize > maxSize)
        {
            Destroy(this);
            BubbleSpawner.GetComponent<SpawnBubble>().doesBubbleExist = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector2(currentSize + growSize, currentSize + growSize);
        }
        
    }
}
