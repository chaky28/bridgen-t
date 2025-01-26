using UnityEngine;

public class FallAfterPop : MonoBehaviour
{
    Rigidbody2D rb;
    public bool wasPopped = false;
    AttachToBubble atb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        atb = GetComponent<AttachToBubble>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wasPopped)
        {
            atb.enabled = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;
            GetComponent<Character>().DisableCharacter();
            wasPopped = false;
        }
    }
}
