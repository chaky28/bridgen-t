using UnityEngine;

public class Character : MonoBehaviour
{
    public RightForce rightForce;
    public float charMass = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightForce.inmediateMass += charMass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
