using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectManager : MonoBehaviour {
    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip pickItem;
    [SerializeField] private AudioClip winClip;

    public static AudioEffectManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayCoinSound() {
        effectAudioSource.PlayOneShot(coinClip);
    }

    public void PlayPickItemSound() {
        effectAudioSource.PlayOneShot(pickItem);
    }

    public void PlayWinSound() {
        effectAudioSource.PlayOneShot(winClip);
    }
}
