using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class updates the player's health meter to see if any obstacles have been hit with enough force to deal damage to the player and controls the shield power up
public class HoverHealthMeter : MonoBehaviour
{
    private float _damageForce = 10; // sets the amount of damage the player will recieve with each obstacle hit
    public Text powerUpText; // Text that displays which power up if any is active or non active
     public bool shieldProtection = false;

    
    
    void OnTriggerEnter(Collider other)
    {
        
        // Displays to the user that the shield power up is now active and sets a 10 second timer of protection to the player
        if (other.gameObject.CompareTag("Shield"))
        {
            StartCoroutine(ShieldProtection());
            other.gameObject.SetActive(false);
            shieldProtection = true;
        }

    }

    // Checks to see if the player has collided with any obstacles with enough force to take damage
    public void OnCollisionEnter(Collision collision)
    {
        // Computes the collison force based off the velocity of the velocity of the player and the obstacle
        float _collisionForce = collision.relativeVelocity.sqrMagnitude; 
      

        // Checks to see if the collision force is greater than the damage force to the obstacle and if the object hit is an obstacle
        // If so the total obstacles in scene will deplete by 1 and update the players health in UIManager

        if ( shieldProtection==false && _collisionForce > _damageForce && collision.gameObject.tag == "Obstacle")
        {
            // updates the number of total obstacles in scene by 1 from the UIManager
            UIManager.instance.totalObstaclesInScene -= 1;

            // Destroys the obstacle
            Destroy(collision.gameObject);

        }

    }

    // Displayers to the user the shield is now active then waits 15 seconds before the player is able to take damage again
    IEnumerator ShieldProtection()
    {
        powerUpText.text = "shield is active now";
        yield return new WaitForSeconds(15);
        changeObstaclesDamageBackOn();

    }

    void changeObstaclesDamageBackOn()
    {
        powerUpText.text = " ";
        shieldProtection = false;

    }


}
