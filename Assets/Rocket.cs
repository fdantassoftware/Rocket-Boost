using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    // Start is called before the first frame update
    Rigidbody rigidyBody;
    AudioSource audioSource;
    void Start() {
        rigidyBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
     
    // Update is called once per frame
    void Update() {
        ProcessInput();
    }

    private void ProcessInput() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidyBody.AddRelativeForce(Vector3.up);
            PlayAudio();
        } else {
            StopAudio();
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward);
        }
    }

    private void PlayAudio() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    private void StopAudio() {
        audioSource.Stop();
    }
}
