using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class controls the UI within the game to displayer the player's health and completion of the game
public class UIManager : MonoBehaviour
{
    public static UIManager instance; // sets instance of UI manager class
    public Slider playerHealthMeter; 
    private GameObject[] obstaclesArray; // array of game objects obstacles
    public int totalObstaclesInScene; 
    public Text winText; // text that displays the completion or non completion of the game
    


    // Initializes variables or states before the application starts.
    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update

    void Start()
    {
        // Extracts the total obstacles in scene
        totalObstaclesInScene = ExtractObstaclesInScene();

        // Set the player's health meter equal to the total number of obstacles in scene
        playerHealthMeter.maxValue = totalObstaclesInScene;
       

    }

    // Update is called once per frame
    void Update()
    {   // Updates the player's health meter to see if any objects in the scene are no longer there
        playerHealthMeter.value = totalObstaclesInScene;

        // Checks to see if the player's health meter is empty and if so will display to the user that they have lost
        if (playerHealthMeter.value == 0)
        {
            winText.text = "You Died! GAME OVER";
            
}

    }

    // Finds all obstacles within the scene with the tag "Obstacle" and puts them in the game object array
    private int ExtractObstaclesInScene()
    {
        obstaclesArray = GameObject.FindGameObjectsWithTag("Obstacle");
       
        return obstaclesArray.Length;

    }

    

}
