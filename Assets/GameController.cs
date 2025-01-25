using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WindArea windArea;
    public WindAreaParticles windAreaParticles;
    public RightForce rightForce;
    private bool windEnabled;
    public int playerLives = 3;
    void Start()
    {
        windEnabled = false;
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
        float randomWindX = Random.Range(0, 2);
        float randomWindY = Random.Range(0, 2);
        windArea.SetWind(randomWindX, randomWindY); 
        windAreaParticles.windForce = new Vector2(randomWindX, randomWindY);
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
        setWind();
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


}
