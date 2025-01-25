using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WindArea windArea;
    public WindAreaParticles windAreaParticles;
    public RightForce rightForce;
    private bool windEnabled;

    void Start()
    {
        windEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!windEnabled)
            {
                enableWind();
                rightForce.applyForceToBubble();
            }
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
}
