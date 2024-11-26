using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < audioClips.Length)
        {
            audioSource.PlayOneShot(audioClips[soundIndex]);
        }
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
    }
}