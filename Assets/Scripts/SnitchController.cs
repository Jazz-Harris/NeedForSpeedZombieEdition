using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This class controls the snitch's behavior and moves the snitch to randomized locations around the  race track
public class SnitchController : MonoBehaviour
{
    private Transform snitchObject;
    public int snitchSpeed; 
    public float snitchHeight = -1.5f;
    GameObject[] snitchPositions; // Array of empty game objects to give the snitch the positions to move to randmoly
    int randomPositions; // sets the new position of the snitch at a random position

    // Start is called before the first frame update
    void Start()
    {   // Gives the snitch a random starting speed
        snitchSpeed = Random.Range(5, 20);

        // Starts the timer to update the snitchs speed every 10 seconds
        StartCoroutine(SpeedRandomizer());

        // Grabs the starting location of the snitch
        transform.position = new Vector3(-112, snitchHeight, 12);
        snitchObject = GameObject.Find("Snitch Ball").transform;

        // Grabs all of the positions within the snitchPosition array
        snitchPositions = GameObject.FindGameObjectsWithTag("SnitchLocation");

        // Allows the different positions in the snitchPosition array to be called at random with each location the snitch could move to
        randomPositions = Random.Range(0, snitchPositions.Length);
        
    }

    // Update is called once per frame
    void Update()
    {   // sets the snitch's speed and smooths the movement
        float stepMovement = snitchSpeed * Time.deltaTime;

        // moves the snitch towards a random empty game object position within the scene
        snitchObject.position = Vector3.MoveTowards(snitchObject.position, snitchPositions[randomPositions].transform.position, stepMovement);

        // Checks to see if the snitch location to close to an empty game object position, if so it will re route the snitch to another randomized position
        if (Vector3.Distance(snitchObject.position, snitchPositions[randomPositions].transform.position) < 0.001f)
        {
            // Picks a new random snitch location
            randomPositions = Random.Range(0, snitchPositions.Length);

            // Puts the snitch onto the new course of the randomized location picked
            snitchPositions[randomPositions].transform.position = snitchPositions[randomPositions].transform.position; 
        }
    }

    // Waits 10 seconds and then will signal for the snitch speed to be changed
    IEnumerator SpeedRandomizer()
    {
        yield return new WaitForSeconds(10);
        changeSpeed();

    }

    // Picks a new random speed for the snitch and starts a new timer over again
    void changeSpeed()
    {
        snitchSpeed = Random.Range(5, 20);
        StartCoroutine(SpeedRandomizer());

    }
}
