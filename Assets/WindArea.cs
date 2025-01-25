using UnityEngine;

public class WindArea : MonoBehaviour
{
    public Vector2 windForce = new Vector2(5f, 0f);
    public ParticleSystem windParticles;

 
    private void Update() { 

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(windForce);
        }
    }

    public void SetWind(float x, float y)
    {
        windForce = new Vector2(x, y);
        ParticleSystem.VelocityOverLifetimeModule velocityModule = windParticles.velocityOverLifetime;
        velocityModule.x = windForce.x;
        velocityModule.y = windForce.y;
    }
   
}