using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    //public value of speed and of moveValue where moveValue is of type Vector2 (2-dimensional vector)
    public GameObject player;
    
    public Vector2 moveValue;
    public float speed;

    private int count;

    private int numPickUps = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    public TextMeshProUGUI PlayerVelocity;
    public Vector3 oldPos;
    private Rigidbody _rigidbody;

    void Start()
     {
         _rigidbody = GetComponent<Rigidbody>();
         oldPos = player.transform.position;
         count = 0;
         winText.text = "";
         SetCountText ();

     }

    //We capture the input in the OnMove function, automatically called by Unity whenever a Move action is executed by the player
    //Input is WASD or arrow keys
    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    public float delayBetweenUpdates = 1f;
    private float timeSinceLastUpdate = 0f;

    void Update() {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= delayBetweenUpdates)
        {
            PlayerVelocity.text = "Player Velocity: " + ((player.transform.position - oldPos).magnitude/Time.deltaTime).ToString("F5") + " m/s";
            oldPos = player.transform.position;
            timeSinceLastUpdate = 0f;
        }
        
    
    }
    
    
    //coding in the FixedUpdate function as the operations involve physics
    void FixedUpdate() {
        //we form a vector with the direction tye ball should move according to input
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        //we are moving the player by applying a physics force, composed of the below variables
        _rigidbody.AddForce(movement * (speed * Time.fixedDeltaTime));
    }

     //OnTriggerEnter() is a function that is called when other games object's collider, congigured as a trigger, collides with the collider of the game object that has this script as a componenent

     void OnTriggerEnter(Collider other) {    
         //We need to check if we are colliding with a pick up - for this we check the tag of the game object
         if (other.gameObject.tag == "PickUp") {
             other.gameObject.SetActive(false); //if we are colliding with a pick-up, we set the game object to inactive
             
             count++;
             SetCountText();
         }
     }


     private void SetCountText() {
         scoreText.text = "Score: " + count.ToString();
         if(count >= numPickUps) {
             winText.text = "You Win!";
         }
     }

     // private void SetPlayerVelocity(){
     //     PlayerVelocity.text = "Player Velocity: " + ((newPos - oldPos)/Time.deltaTime).ToString();
     // }
}