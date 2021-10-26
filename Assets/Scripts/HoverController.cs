using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class controls the timer and alerts the player to the game status

public class HoverController : MonoBehaviour
{
    private Rigidbody playerRB; // Calls the rigid body attached to the player
    public Text winText;  // text that displays the completion or non completion of the game
    public Text timerText; // text that displays ther timer
    private Vector3 startPosition; // position of the player upon the game start
    private float startTime;
    public string minutes;
    public string seconds;
    float endTimer; // timer that signals the player has passed the 5 minute mark to reach the snitch
    public bool isTimerOn = true; // boolean that checks if the timer is past or within 5 minutes since the games launched

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Grabs the ridig body attached to the player
        winText.text = ""; // initalizes the win text
        
        startPosition = transform.position; // Grabs the starting position of the  player
        startTime = Time.time; // starts the timer
    }

    // Update is called once per frame
    void Update()
    {
        // calculates in game time to be displayed to the user
        float time = Time.time - startTime;
        
         minutes = ((int)time / 60).ToString();
        seconds = (time % 60).ToString("f2");

        // Checks that the timer will be displayed unless the timer is switched off (past 5 minutes)
        if (isTimerOn == true)
        {
            timerText.text = minutes + ":" + seconds;
        }

        if(time >= 300)
        {
            isTimerOn = false;
            winText.text = "Mission failed";
        }
        
    }
    
    // Checks to see if the player has collided with the snitch and toggles an update to the UI to display the game status to the user
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Snitch") && isTimerOn == true && UIManager.instance.playerHealthMeter.value > 0)
        {
            isTimerOn = false;
            timerText.text = " ";
            other.gameObject.SetActive(false);
            winText.text = "Snitch Captured! You Win!!!";
       }

        
    }







}