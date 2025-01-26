using UnityEngine;

public class RightForce : MonoBehaviour
{
    public float rForce = 1;
    public float uForce = 1;
    public float gravityScale = .5f;
    public float initialMass = 5f;
    public float inmediateMass = 5f;
    public int intervalBetweenMasses = 60;
    private int currentInterval = 0;
    private bool forceWasApplied = false;
    public float goUpDiff = 2f;
    private Rigidbody2D rb;
    public BubbleBlowUpController bubbleBlowUpController;
    public float inmediateMassMultiplier;
    public MicrophoneInput microphoneInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (microphoneInput == null)
        {
            microphoneInput = FindFirstObjectByType<MicrophoneInput>();
        }

        if (forceWasApplied)
        {
            if (currentInterval < intervalBetweenMasses)
            {
                currentInterval++;
            }
            else
            {
                Debug.Log("Applying inmediate mass");
                rb.mass = inmediateMass;
            }
        }
    }

    public void applyForceToBubble()
    {
        
        if (microphoneInput.isRaging) {
            rb.AddForce(new Vector2(rForce + 100000, uForce));
            bubbleBlowUpController.isFlying = true;
            forceWasApplied = true;
        }
        else
        {
            rb.mass = initialMass;
            inmediateMass -= bubbleBlowUpController.transform.localScale.x * inmediateMassMultiplier;
            if (initialMass - inmediateMass > goUpDiff)
            {
                rb.gravityScale = -gravityScale;
            }
            else
            {
                rb.gravityScale = gravityScale;
            }

            rb.AddForce(new Vector2(rForce, uForce));
            bubbleBlowUpController.isFlying = true;
            forceWasApplied = true;
        }

        
    }

    public void applyForceToBubbleDown()
    {
            rb.AddForce(new Vector2(2000, -2));
            bubbleBlowUpController.isFlying = true;
            forceWasApplied = true;
        
    }
}
