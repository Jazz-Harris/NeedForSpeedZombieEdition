using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class rotates the power ups within the game to add an effect
public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    // sets the power up on an angle and rotates it smoothly 
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
