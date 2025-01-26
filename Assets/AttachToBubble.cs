using UnityEngine;

public class AttachToBubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BubbleBlowUpController bubbleSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleSprite != null)
        {
            transform.position = new Vector2(bubbleSprite.transform.position.x, bubbleSprite.transform.position.y - .47f);

        }
    }

    public void FindBubble()
    {
        bubbleSprite = FindFirstObjectByType<BubbleBlowUpController>();
    }

}
