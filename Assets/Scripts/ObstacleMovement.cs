using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls the horizontal movement of the obstacles within the game
public class ObstacleMovement : MonoBehaviour
{
    public float speedMovement = 1.2f; // sets the obstacles speed
    public Vector3 startPosition; // sets the start position of each obstacle
    public float movementLength = 3f; // length of movement the obstacles can reach ( left to right) from its original starting position
   

    // Start is called before the first frame update
    void Start()
    {   // grabs the position of obstacle at start
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {   // moves the obstacle from left to right on a cycle while the game is in play
        Vector3 obstacle = startPosition;
        obstacle.x += movementLength * Mathf.Sin(Time.time * speedMovement);
        transform.position = obstacle;
    }

  
}