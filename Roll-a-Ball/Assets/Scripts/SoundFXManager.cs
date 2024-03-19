using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip[] audioClips, Transform transform, float volume) {
        AudioClip audioClip = audioClips[Random.Range(0, audioClips.Length)];

        AudioSource audioSource = Instantiate(soundFXObject, transform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        Destroy(audioSource.gameObject, audioClip.length);
    }
}
