using UnityEngine;

public class Character : MonoBehaviour
{
    public RightForce rightForce;
    public float charMass = 15f;
    private Animator anim;
    public bool isOnBubble;
    public bool isCurrentCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightForce.inmediateMass += charMass;
        anim = GetComponent<Animator>();
        isOnBubble = false;
        isCurrentCharacter = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setOnBubble()
    {
        isOnBubble = true;
        anim.SetBool("bubbled", true);
    }

    public void setOffBubble()
    {
        isOnBubble = false;
        anim.SetBool("bubbled", false);
    }

    public void setAsCurrentCharacter()
    {
        isCurrentCharacter = true;
    }

    public void setAsNotCurrentCharacter()
    {
        isCurrentCharacter = false;
    }
}
