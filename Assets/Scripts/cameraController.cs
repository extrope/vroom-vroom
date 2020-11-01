using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    //create empty objects and empty array to hold camera locations
    private GameObject vehicle;
    private GameObject cameras;
    private Transform[] camLocations;

    //create public variable to hold iterator for camera location array
    public int locationIndicator = 2;
    //define time for camera to chase vehicle
    [Range(0,20)]public float smothTime = 5;
    
    //assign empty objects with real game objects and get the location of each camera
    private void Start() {
        vehicle = GameObject.FindGameObjectWithTag("Player");
        cameras = vehicle.transform.Find("Camera").gameObject;
        camLocations = cameras.GetComponentsInChildren<Transform>();
    }
    //create button to cycle through the camlocations array
    private void FixedUpdate() {
        cameraBehavior();
        if(Input.GetKeyDown(KeyCode.Tab)){
            //change camLocation
            if(locationIndicator >= 3 || locationIndicator < 2 ) locationIndicator = 2;
               else locationIndicator ++;
            
        }
    }
    //changes the current primary camera and the position of the camera
    private void cameraBehavior(){
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position,camLocations[locationIndicator].transform.position,ref velocity,smothTime * Time.deltaTime);
        transform.LookAt(camLocations[1].transform);
    }

}
