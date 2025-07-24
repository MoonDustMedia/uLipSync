using UnityEngine;

namespace uLipSync
{

[RequireComponent(typeof(AudioSource))]
public class uLipSyncAudioSource : MonoBehaviour
{
    bool IsEnabled;
        
    public AudioFilterReadEvent onAudioFilterRead { get; private set; } = new AudioFilterReadEvent();

    void OnAudioFilterRead(float[] input, int channels)
    {
        lock (this)
        {
            if (onAudioFilterRead != null && IsEnabled)
            {
                onAudioFilterRead.Invoke(input, channels);
            }
        }
    }

    void OnEnable()
    {
        lock (this)
        {
            IsEnabled = true;
        }
    }

    void OnDisable()
    {
        lock (this)
        {
            IsEnabled = false;
        }
    }
}

}
