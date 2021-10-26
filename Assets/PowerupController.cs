using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class controls the interaction between the player and speed up power up
public class PowerupController : MonoBehaviour
{
    public static PowerupController instance; // sets instance of PowerUpController class
    public float speed = 15f; // Front and back speed of the player
    public Text powerUpText; // Text that displays which power up if any is active or non active

   
    // Start is called before the first frame update
    void Start()
    {
        powerUpText.text = "";

    }

    // Checks to see if the player has collided with either the speed or shield powerup
    void OnTriggerEnter(Collider other)
    {
        // Displays to user that the speed power up is active and sets an accelerated speed for 10 seconds
        if (other.gameObject.CompareTag("SpeedPowerUp"))
        {
            powerUpText.text = "speed power is now active";
            speed = 30f;
            StartCoroutine(SpeedBoostTime());
            Destroy(other.gameObject);

        }

    }

    // Allows the player to have an accerlated speed for 10 seconds then calls method to change the speed back
    IEnumerator SpeedBoostTime()
    {
        yield return new WaitForSeconds(10);
        changeSpeedBack();

    }

    // resets the players speed to the default speed
    void changeSpeedBack()
    {
        speed = 15f;
        powerUpText.text = "";
    }

    
}
