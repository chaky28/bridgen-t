using UnityEngine;

public class SoundController : MonoBehaviour
{
    public PlaySound playStartUpSound;
    public PlaySound playLooserSound;
    public PlaySound playPopSound;
    public PlaySound playWindSound;
    public PlaySound playMusicSound;
    public PlaySound playClickSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlaySound("Song");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            PlaySound("Click");
        }
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
        else if (soundName == "Song")
        {
            playMusicSound.Play();
        }
        else if (soundName == "Click")
        {
            playClickSound.Play();
        }

    }

}
