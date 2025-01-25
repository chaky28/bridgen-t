using Unity.VisualScripting;
using UnityEngine;

public class BubbleBlowUpController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float growingRate;
    public MicrophoneInput microphoneInput;
    public float shrinkRate;
    public float MAX_SIZE;
    public bool isFlying = false; 
    private Animator anim;
    public bool isMoving;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(microphoneInput.isDetecting);
        if (microphoneInput.isDetecting)
        {
            float growMultiplier = growingRate * Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x + growMultiplier, transform.localScale.y + growMultiplier, transform.localScale.z);
            if (transform.localScale.x >= MAX_SIZE)
            {
                TriggerDestroy();
            }
        }
        else
        {
            if (transform.localScale.x >= .9f && !isFlying)
            {
                transform.localScale = new Vector3(transform.localScale.x - shrinkRate, transform.localScale.y - shrinkRate, transform.localScale.z);

            }

        }

    }

    void TriggerDestroy()
    {
        anim.SetTrigger("pop");
    }
}
