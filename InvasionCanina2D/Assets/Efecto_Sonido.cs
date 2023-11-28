using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efecto_Sonido : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PerroMele")
        {
            audioSource.Play();
        }
    }

}
