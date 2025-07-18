using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip coinClip;

    public static AudioManager Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        PlayBackGroundMusic();
    }

    public void PlayBackGroundMusic() {
        backgroundAudioSource.clip = backGroundClip;
        backgroundAudioSource.Play();
    }

    public void PauseBackGroundMusic() {
        backgroundAudioSource.Pause();
    }

    public void PlayCoinSound() {
        effectAudioSource.PlayOneShot(coinClip);
    }
}
