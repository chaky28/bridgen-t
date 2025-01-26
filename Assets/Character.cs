using UnityEngine;

public class Character : MonoBehaviour
{
    public RightForce rightForce;
    public float charMass = 15f;
    private Animator anim;
    public bool isOnBubble;
    public bool isCurrentCharacter;
    Transform bubbleSpawnerTransformPosition;
    private AttachToBubble attachToBubbleScript;
    bool moving;
    float moveSpeed = 1f;
    Transform pointToMove;
    CharacterSpawner characterSpawner;
    public SoundController soundController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isOnBubble = false;
        bubbleSpawnerTransformPosition = GameObject.Find("BubbleSpawnLocation").GetComponent<Transform>();
        attachToBubbleScript = GetComponent<AttachToBubble>();
        characterSpawner = FindFirstObjectByType<CharacterSpawner>();
        if (soundController == null)
        {
            soundController = FindFirstObjectByType<SoundController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (moving && transform.position.x < pointToMove.position.x)
        {
            transform.position = new Vector3 (transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (moving && transform.position.x >= pointToMove.position.x)
        {
            moving = false;
            anim.SetBool("moving", false);

        }


        if (Input.GetKeyDown(KeyCode.K)) {
            HopOnBubble();
        }
    }

    public void setOnBubble()
    {
        attachToBubbleScript.FindBubble();
        rightForce = FindFirstObjectByType<RightForce>();
        rightForce.inmediateMass += charMass;
        transform.position = (Vector2)bubbleSpawnerTransformPosition.position;
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

    public void HopOnBubble()
    {
        setOnBubble();
    }

    public void MoveToPoint(Transform moveTowards)
    {
        moving = true;
        pointToMove = moveTowards;
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("moving", true);
    }

    public void DisableCharacter(bool destroy=false)
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("moving", true);
        if (!destroy)
        {
            Invoke("TurnOffCharacters", 1f);

        }
        
        if (destroy)
        {
            Invoke("DestroyCharacter", 1f);
        }


    }

    void TurnOffCharacters()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("moving", true);
        GetComponent<FallAfterPop>().enabled = false;
        GetComponent<AttachToBubble>().enabled = false;
        GetComponent<Character>().enabled = false;
        characterSpawner.ReplacePlayers();

    }
    void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}
