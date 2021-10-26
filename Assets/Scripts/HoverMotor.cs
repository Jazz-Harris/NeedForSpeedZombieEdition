using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class sets and controls the speed and direction from the user to the player
public class HoverMotor : MonoBehaviour
{  
    public float speed = 15f; // Front and back speed of the player
    public float turnSpeed = 5f; // Turn speed of the player
    public float hoverForce = 13f; 
    public float hoverHeight = 2.5f;
    public Text powerUpText; // Text that displays which power up if any is active or non active
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        powerUpText.text = "";
       
    }

    // Initializes variables or states before the application starts.
    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()

    {   // Checks every frame for directional input to the player from the user
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        
    }
    // It is called every fixed frame-rate frame. Compute Physics system calculations
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // Computes the physics for the player to hover and be moved in any direction (front,left,right,back)
        if(Physics.Raycast(ray, out hit, hoverHeight))
        {   
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce * Time.smoothDeltaTime;
            carRigidbody.AddForce(appliedHoverForce,ForceMode.Acceleration);
        }
        // Adds force and torque to the player 
        carRigidbody.AddRelativeForce(2f, 2f, powerInput * speed);
        carRigidbody.AddRelativeTorque(2f, turnInput * turnSpeed, 2f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            carRigidbody.isKinematic = true;
        }

    }
    private void OnCollisionExit(Collision other)
    {
        
        {
            carRigidbody.isKinematic = false;
        }

    }
}
