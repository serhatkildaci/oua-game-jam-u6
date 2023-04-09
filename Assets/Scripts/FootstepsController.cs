using UnityEngine;

public class FootstepsController : MonoBehaviour
{

    public AudioClip audio;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            // Set the audio clip to the running audio clip
            audioSource.clip = audio;

            // If the audio clip is not already playing, play it
            if (!audioSource.isPlaying)
            {
                Debug.Log("Playing footsteps sound");
                audioSource.Play();
            }
        }
        else
        {
            // Stop the audio clip if it's playing
            if (audioSource.isPlaying)
            {
                Debug.Log("Stopping footsteps sound");
                audioSource.Stop();
            }
        }
    }
}
