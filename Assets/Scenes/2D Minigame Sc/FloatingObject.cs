using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // The amplitude of the floating motion
    public float speed = 1f; // The speed of the floating motion
    private float startY; // The starting Y position of the object

    private void Start()
    {
        startY = transform.position.y; // Store the starting Y position of the object
    }

    private void Update()
    {
        // Calculate the new Y position of the object using a sinusoidal function
        float newY = startY + amplitude * Mathf.Sin(Time.time * speed);
        
        // Set the object's position to the new Y position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
