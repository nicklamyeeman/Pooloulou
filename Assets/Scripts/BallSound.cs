using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BallSound : MonoBehaviour
{
    AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if ((obj.CompareTag("Red") || obj.CompareTag("Yellow") ||
            obj.CompareTag("CueBall") || obj.CompareTag("Black")) && rb.velocity.magnitude > 0.1)
            sound.Play();

    }
}
