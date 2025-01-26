using UnityEngine;

public class BelowBoundary : MonoBehaviour
{
    public SoundController soundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (soundController == null)
        {
            soundController = FindFirstObjectByType<SoundController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            collision.collider.GetComponent<Character>().DisableCharacter(true);
            soundController.PlaySound("Looser");
        }
    }
}
