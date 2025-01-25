using UnityEngine;

public class OnCollition : MonoBehaviour
{
    public BubbleBlowUpController bubbleBlowUpController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        bubbleBlowUpController.TriggerDestroy();
        Debug.Log("Collided with upper boundry");
    }
}
