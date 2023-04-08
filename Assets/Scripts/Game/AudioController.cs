using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController: MonoBehaviour {
    public static AudioController current;
    public AudioClip projectileSFX;
    public AudioClip explosionSFX;
    public AudioClip hitSFX;

    AudioSource AudioSrc;
    
    void Start() {
        current = this;
        AudioSrc = GetComponent<AudioSource>();
    }

    void Update() {
        
    }

    public void PlayAudio(AudioClip clip) {
        AudioSrc.PlayOneShot(clip);
    }
}
