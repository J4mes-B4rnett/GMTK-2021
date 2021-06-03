using UnityEngine;
using System.Collections.Generic;

public class scr_audio_manager : MonoBehaviour {

    public static scr_audio_manager audioManager;

    [SerializeField] private List<AudioData> audioList;
    private AudioSource gloabalAudioSource;//global as in it can be heard anywhere without any stereo effect.

    private void Start() {
        DontDestroyOnLoad(gameObject);
        if (audioManager == null) audioManager = this;
        else Destroy(gameObject);

        gloabalAudioSource = gameObject.GetComponent<AudioSource>();
        gloabalAudioSource.playOnAwake = false;
    }

    public void PlaySound(string soundName, float volume = 1) {
        AudioData playedSound = audioList.Find(sound => sound.name == soundName);
        if (playedSound == null) Debug.LogError($"The Sound, {soundName} could not be found.");
        else gloabalAudioSource.PlayOneShot(playedSound.audioClip, volume);
    }

    public void PlaySoundAtPosition(string soundName, Vector3 position, float falloff, bool useStereo) {
        AudioData playedSound = audioList.Find(sound => sound.name == soundName);
        if (playedSound == null) Debug.LogError($"The Sound, {soundName} could not be found.");
        else {
            AudioSource audioObject = new GameObject("Audio Object").AddComponent<AudioSource>();
            audioObject.clip = playedSound.audioClip;
            audioObject.transform.position = position;
            audioObject.rolloffMode = AudioRolloffMode.Linear;
            audioObject.minDistance = 0;
            audioObject.maxDistance = falloff;
            audioObject.spatialBlend = 1;
            audioObject.dopplerLevel = 0;
            if (!useStereo) audioObject.spread = 180;
            audioObject.Play();
            audioObject.gameObject.AddComponent<scr_audio_object>();
        }
    }
}

[System.Serializable]
class AudioData {
    public string name;
    public AudioClip audioClip;
}