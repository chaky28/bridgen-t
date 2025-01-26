using UnityEngine;

public class DetectSavedCharacter : MonoBehaviour
{
    public int savedCharacters = 0;
    public GameController gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Character"))
        {
            savedCharacters++;
            gameController.savedCharacters.Add(collider.gameObject);
        }
    }
}
