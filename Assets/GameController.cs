using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public WindArea windArea;
    public WindAreaParticles windAreaParticles;
    public RightForce rightForce;
    public float maxWindForce = 2;
    private bool windEnabled;

    void Start()
    {
        windEnabled = false;
        setWind();
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
}
