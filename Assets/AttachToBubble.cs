using UnityEngine;

public class AttachToBubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bubbleSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(bubbleSprite.transform.position.x, bubbleSprite.transform.position.y - .65f);
    }
}
