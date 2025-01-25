using UnityEngine;

public class WindAreaParticles : MonoBehaviour
{
    public Vector2 windForce = new Vector2(5f, 0f); 

    private void OnTriggerStay2D(Collider2D collision)
    {
        ParticleSystem particleSystem = collision.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
            int numParticlesAlive = particleSystem.GetParticles(particles);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].velocity += (Vector3)windForce * Time.deltaTime;
            }

            particleSystem.SetParticles(particles, numParticlesAlive);
        }
    }
}