using UnityEngine;
using UnityEngine.UI;

public class MicrophoneInput : MonoBehaviour
{
    public string microphoneName; 
    public float sensitivity = 0.5f; 
    public int sampleWindow = 128; 
    private AudioClip microphoneClip;
    public bool isDetecting = false;
    public Slider sensitivitySlider; 
    public Text sensitivityText;

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

        // Initialize slider value and text
        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = 0.5f; // Default sensitivity
            UpdateSensitivityText();
        }
    }

    void Update()
    {
        if (microphoneClip != null && Microphone.IsRecording(microphoneName))
        {
            if (sensitivitySlider != null)
            {
                sensitivity = sensitivitySlider.value;
                UpdateSensitivityText();
            }


            float volume = GetMicrophoneVolume();
            //Debug.Log("Volume: " + volume);

            // Detect blowing based on volume threshold
            if (volume > sensitivitySlider.value)
            {
                Debug.Log("Blowing detected!");
                isDetecting = true;
            }
            else if (volume <= sensitivitySlider.value)
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

    void UpdateSensitivityText()
    {
        if (sensitivityText != null)
        {
            sensitivityText.text = "Sensitivity: " + sensitivitySlider.value.ToString("F2");
        }
    }

    void OnApplicationQuit()
    {
        if (Microphone.IsRecording(microphoneName))
        {
            Microphone.End(microphoneName);
        }
    }

}