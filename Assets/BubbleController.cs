using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public SoundController soundController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (soundController == null)
        {
            soundController = FindFirstObjectByType<SoundController>();
        }
    }

    public void TriggerDestroy()
    {
        soundController.PlaySound("Pop");

        Invoke("DestroyInaSec", .5f);
    }

    void DestroyInaSec()
    {

        Destroy(gameObject);

    }
}
