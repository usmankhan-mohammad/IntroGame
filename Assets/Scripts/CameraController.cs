using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //public game object, the player, the target of the camera
    public GameObject player;
    //private offset, from the player to the camera
    private Vector3 offset;


    public TextMeshProUGUI PlayerPosition;

    //Start() initialises the offset, this takes the initial position of the camera
    //(note we can use the initialisation because player is at origin)
    void Start() {
        //we modify the position of the camera by adding the offset to the position of the player
        offset = transform.position;
    }

    //we are doing this on the LateUpdate() method, this is the appropriate place for the follow cameras, procedural animations and gathering last known states
    void LateUpdate(){
        transform.position = player.transform.position + offset;
        SetPositionText();
    }
    
    
    private void SetPositionText()
    {
        PlayerPosition.text = "Player Position: " + player.transform.position.ToString();
    }
}
