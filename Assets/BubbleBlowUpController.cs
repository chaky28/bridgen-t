using Unity.VisualScripting;
using UnityEngine;

public class BubbleBlowUpController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float growingRate;
    public MicrophoneInput microphoneInput;
    private SpriteRenderer sr;
    public float shrinkRate;
    public float MAX_SIZE;
    public bool isFlying = false;
    public RightForce rightForce;
    public float inmediateMassDelta = 1f;
    public FallAfterPop fallAfterPop;
    private Animator anim;
    public Animator sopaHeadanim;
    public float warningThreshold = .3f;
    private GameController gameController;
    void Start()
    {
        anim = GetComponent<Animator>();
        sopaHeadanim = GameObject.Find("Head").GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        gameController = FindFirstObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (microphoneInput == null) { 
            microphoneInput = FindFirstObjectByType<MicrophoneInput>();
        }
        if (fallAfterPop == null)
        {
            fallAfterPop = gameController.activeCharacter.GetComponent<FallAfterPop>();
        }

        Debug.Log(microphoneInput.isDetecting);


        if (microphoneInput.isRaging)
        {
            transform.localScale = new Vector3(MAX_SIZE, MAX_SIZE, transform.localScale.z);
            sr.color = Color.yellow;
        }

        else if (microphoneInput.isDetecting)
        {
            float growMultiplier = growingRate * Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x + growMultiplier, transform.localScale.y + growMultiplier, transform.localScale.z);
            sopaHeadanim.SetBool("press", true);

            if (transform.localScale.x >= MAX_SIZE)
            {
                TriggerDestroy();
            }
        }
        else
        {
            sopaHeadanim.SetBool("press", false);

            if (transform.localScale.x >= .99f && !isFlying)
            {
                transform.localScale = new Vector3(transform.localScale.x - shrinkRate, transform.localScale.y - shrinkRate, transform.localScale.z);
            }

        }

    }

    public void TriggerDestroy()
    {
        gameController.LaunchPlayerDown();
        anim.SetTrigger("pop");
        fallAfterPop.wasPopped = true;
        GetComponentInParent<BubbleController>().TriggerDestroy();
    }
}
