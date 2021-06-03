using UnityEngine;

public class scr_audio_object : MonoBehaviour {

    private AudioSource audioSource;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update() {
        if (!audioSource.isPlaying) Destroy(gameObject);
    }
}