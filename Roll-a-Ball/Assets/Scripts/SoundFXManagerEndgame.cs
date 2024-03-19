using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManagerEndgame : MonoBehaviour
{
    public static SoundFXManagerEndgame instance;

    [SerializeField] private AudioSource soundFXObject;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform transform, float volume) {

        AudioSource audioSource = Instantiate(soundFXObject, transform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        Destroy(audioSource.gameObject, audioClip.length);
    }
}
