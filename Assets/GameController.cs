using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WindArea windArea;
    public WindAreaParticles windAreaParticles;
    public WindAreaParticles windAreaParticles2;
    public WindAreaParticles windAreaParticles3;
    public RightForce rightForce;
    public float maxWindForce = 2;
    private bool windEnabled;
    public int playerLives = 3;
    public Character activeCharacter;
    private string gameState; // Ready, Preparing, Flying 
    

    void Start()
    {
        gameState = "Ready";
        windEnabled = false;
        setWind();
    }

    // Update is called once per frame
    void Update()
    {
        // Restart the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindActiveCharacter();
            if (!windEnabled)
            {
                enableWind();
                rightForce.applyForceToBubble();
            }
            else
                disableWind();
        }
    }

    void setWind()
    {
        float randomWindX = Random.Range(-maxWindForce, maxWindForce);
        float randomWindY = Random.Range(-maxWindForce, maxWindForce);
        windArea.SetWind(randomWindX, randomWindY); 
        windAreaParticles.windForce = new Vector2(randomWindX, randomWindY);
        windAreaParticles2.windForce = new Vector2(randomWindX, randomWindY);
        windAreaParticles3.windForce = new Vector2(randomWindX, randomWindY);


    }

    void disableWind()
    {
        windArea.enabled = false;
        windArea.GetComponent<BoxCollider2D>().enabled = false;
        windEnabled = false;
        setWind(); // When disabling the wind, set a new random wind for the next round
    }

    void enableWind()
    {
        windArea.enabled = true;
        windArea.GetComponent<BoxCollider2D>().enabled = true;
        windEnabled = true;
    }

    int GetLives()
    {
        return playerLives;
    }

    void LoseLife()
    {
        playerLives -= 1;
    }

    void FindActiveCharacter()
    {
        var characters = FindObjectsByType<Character>(FindObjectsSortMode.None);
        Character targetCharacter = characters.FirstOrDefault(character => character.isCurrentCharacter);
        activeCharacter = targetCharacter;
    }
}
