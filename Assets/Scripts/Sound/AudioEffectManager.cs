using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectManager : MonoBehaviour {
    public static AudioEffectManager Instance { get; private set; }

    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip pickItem;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip leavesClip;
    [SerializeField] private AudioClip doorClip;

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

    public void PlayLeavesSound() {
        effectAudioSource.PlayOneShot(leavesClip);
    }

    public void PlayDoorSound() {
        effectAudioSource.PlayOneShot(doorClip);
    }
}
