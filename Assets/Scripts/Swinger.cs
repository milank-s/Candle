using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinger : MonoBehaviour
{
    public float rotationAngle = 45f;   // Maximum angle to rotate
    public float rotationSpeed = 45f;   // Speed of rotation in degrees per second

    private Quaternion startingRotation; // Initial rotation of the object
    private float currentAngle;          // Current angle of rotation
    private bool isPlaying = true;       // Flag to control rotation state

    void Start()
    {
        startingRotation = transform.rotation;
        currentAngle = 0f;
    }

    void Update()
    {
        if (isPlaying)
        {
            // Calculate the desired rotation angle based on sine function for back and forth motion
            float targetAngle = Mathf.Sin(Time.time * rotationSpeed * Mathf.Deg2Rad) * rotationAngle;

            // Smoothly rotate towards the target angle
            currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * 5f); // Adjust the last parameter to control rotation smoothness
        }
        else
        {
            // Return to starting rotation when not playing
            currentAngle = Mathf.Lerp(currentAngle, 0f, Time.deltaTime * 5f); // Adjust the last parameter to control return smoothness
        }

        // Apply the rotation to the object
        transform.rotation = startingRotation * Quaternion.Euler(0f, currentAngle, 0f);
    }

    // Method to toggle rotation state
    public void Play()
    {
        isPlaying = true;
    }

    public void Stop()
    {
        isPlaying = false;
    }
}
