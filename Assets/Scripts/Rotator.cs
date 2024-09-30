using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    
    //Update is called once per frame
    //Update is being used because the movement is not an effect on any physics reaction
    //We are applying arbritrary rotation in the three axes, smoothing it with the time between frames
    void Update() {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
