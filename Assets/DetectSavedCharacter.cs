using UnityEngine;

public class DetectSavedCharacter : MonoBehaviour
{
    public int savedCharacters = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            savedCharacters++;
        }
    }
}
