using UnityEngine;

public class RightForce : MonoBehaviour
{
    public float rForce = 1;
    public float uForce = 1;
    public float gravityScale = .5f;
    private Rigidbody2D rb;
    public BubbleBlowUpController bubbleBlowUpController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void applyForceToBubble()
    {
        rb.AddForce(new Vector2(rForce, uForce));
        rb.gravityScale = gravityScale;
        bubbleBlowUpController.isFlying = true;
    }
}
