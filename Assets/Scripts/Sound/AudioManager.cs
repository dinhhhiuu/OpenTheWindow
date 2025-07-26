using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioClip backGroundClip;

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
}
