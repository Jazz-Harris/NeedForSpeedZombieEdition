using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the behavior of the camera in conjuction to the player
public class CameraController : MonoBehaviour
{

    public GameObject player; //Public variable to store a reference to the player game object
    private Vector3 offset; //Private variable to store the offset distance between the player and camera
    public Transform target;
    private float xMin = -1.0f, xMax = 1.0f;
    private float timeValue = 0.0f;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        transform.LookAt(target, Vector3.left);

        // Compute the sin position.
        float xValue = Mathf.Sin(timeValue * 5.0f);

        // Now compute the Clamp value.
        float xPos = Mathf.Clamp(xValue, xMin, xMax);

        // Update the position of the cube.
        transform.position = new Vector3(xPos, 0.0f, 0.0f);

        // Increase animation time.
        timeValue = timeValue + Time.deltaTime;

        // Reset the animation time if it is greater than the planned time.
        if (xValue > Mathf.PI * 2.0f)
        {
            timeValue = 0.0f;
        }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

    }
    
}
