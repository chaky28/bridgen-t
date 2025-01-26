using UnityEngine;

public class SoundController : MonoBehaviour
{
    public PlaySound playStartUpSound;
    public PlaySound playLooserSound;
    public PlaySound playPopSound;
    public PlaySound playWindSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string soundName)
    {
        if (soundName == "StartUp")
        {
            playStartUpSound.Play();
        } 
        else if (soundName == "Looser")
        {
            playLooserSound.Play();
        }
        else if (soundName == "Pop")
        {
            playPopSound.Play();
        }
        else if (soundName == "Wind")
        {
            playWindSound.Play();
        }

    }

}
