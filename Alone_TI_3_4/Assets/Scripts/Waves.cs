using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    

    // Wave Properties
    public float amplitude = 0.5f; // Height of the wave
    public float frequency = 1f; // Speed of the wave
    public float movementSpeed = 1f; // Speed the wave advances
    public float fadeTime = 1f; // Time it takes for the wave to fade in/out

    // Private Variables
    private float timer = 0f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calculate wave movement
        float waveHeight = amplitude * Mathf.Sin(timer * frequency);
        timer += Time.deltaTime * movementSpeed;

        // Fade the wave in/out
        float alpha = Mathf.Lerp(0f, 1f, Mathf.Clamp01(timer / fadeTime));
        GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, alpha);

        // Apply wave movement and fade
        transform.position = originalPosition + Vector3.up * waveHeight;
    }
}

