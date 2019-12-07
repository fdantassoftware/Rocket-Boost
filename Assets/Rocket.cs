using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    // Start is called before the first frame update
    Rigidbody rigidyBody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 300f;
    [SerializeField] float mainThrust = 100f;

    void Start() {
        rigidyBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
     
    // Update is called once per frame
    void Update() {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Friendly":
                break;
            default:
                print("Kill it fast dude!");
                break;
        }
    }
     
    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidyBody.AddRelativeForce(Vector3.up * mainThrust);
            PlayAudio();
        } else {
            StopAudio();
        }
    }
    private void Rotate() {
        rigidyBody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidyBody.freezeRotation = false;
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
