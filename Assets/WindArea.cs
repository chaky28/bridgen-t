using UnityEngine;

public class WindArea : MonoBehaviour
{
    public Vector2 windForce = new Vector2(5f, 0f);
    public ParticleSystem windParticles;
    public ParticleSystem windParticles2;
    public ParticleSystem windParticles3;


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
        ParticleSystem.VelocityOverLifetimeModule velocityModule2 = windParticles2.velocityOverLifetime;

        ParticleSystem.VelocityOverLifetimeModule velocityModule3 = windParticles3.velocityOverLifetime;

        velocityModule.x = windForce.x;
        velocityModule.y = windForce.y;

        velocityModule2.x = windForce.x;
        velocityModule2.y = windForce.y;

        velocityModule3.x = windForce.x;
        velocityModule3.y = windForce.y;
    }
   
}