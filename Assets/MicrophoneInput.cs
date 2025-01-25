using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public string microphoneName; // Optional: Specify a microphone by name
    public float sensitivity = 0.5f; // Sensitivity threshold for detecting blowing
    public int sampleWindow = 128; // Number of audio samples to analyze
    private AudioClip microphoneClip;
    public bool isDetecting = false;

    void Start()
    {
        // List available microphones
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Microphone: " + device);
        }

        // Start recording from the default microphone or the specified one
        microphoneName = Microphone.devices.Length > 0 ? Microphone.devices[0] : null;

        if (microphoneName != null)
        {
            microphoneClip = Microphone.Start(microphoneName, true, 10, AudioSettings.outputSampleRate);
            Debug.Log("Recording started with " + microphoneName);
        }
        else
        {
            Debug.LogError("No microphone detected!");
        }
    }

    void Update()
    {
        if (microphoneClip != null && Microphone.IsRecording(microphoneName))
        {
            float volume = GetMicrophoneVolume();
            //Debug.Log("Volume: " + volume);

            // Detect blowing based on volume threshold
            if (volume > sensitivity)
            {
                Debug.Log("Blowing detected!");
                isDetecting = true;
            }
            else if (volume <= sensitivity && isDetecting)
            {
                isDetecting = false;
            }
        }
    }

    float GetMicrophoneVolume()
    {
        if (microphoneClip == null) return 0f;

        float[] data = new float[sampleWindow];
        int position = Microphone.GetPosition(microphoneName) - sampleWindow + 1;
        if (position < 0) return 0f;

        microphoneClip.GetData(data, position);

        // Calculate RMS value of the audio data
        float sum = 0f;
        foreach (float sample in data)
        {
            sum += sample * sample;
        }
        return Mathf.Sqrt(sum / data.Length);
    }

    void OnApplicationQuit()
    {
        if (Microphone.IsRecording(microphoneName))
        {
            Microphone.End(microphoneName);
        }
    }
}