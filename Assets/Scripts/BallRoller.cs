using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoller : MonoBehaviour
{
    public int level = 1;
    public float torqueAmount;
    public GameObject PlayerBall;
    public Rigidbody ballRigidbody;
    public Transform PlayerTransform;
    private Vector3 cameraOffset;

    private Camera mainCamera; //caching the camera for limited calls to Camera.main 

    private bool isPressing = false;
    private Vector2 originalPressPoint = Vector2.zero;

    private void Awake()
    {
        //all initialization logic here
        MyEventSystem.I.StartLevel(level);
        ballRigidbody = PlayerBall.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        //cameraOffset = GameObject.Find("PlayerBall").transform.position - Camera.main.transform.position;
        //caching the main camera's offset relative to the player
        cameraOffset = PlayerBall.transform.position - mainCamera.transform.position;
    }
    
    private void Update(){
        //the movment of the mainCamera should stay proportional to the framerate
        mainCamera.transform.position = PlayerTransform.position - cameraOffset;
    }

    //the character controlls should be independant of the framerate
    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0)){
            if(!isPressing){
                originalPressPoint = Input.mousePosition;
                isPressing = true;
            }
            else{
                Vector2 diff = (originalPressPoint - new Vector2(Input.mousePosition.x, Input.mousePosition.y)).normalized;
                //used cached reference to avoid calling PlayerBall.GetComponent<RigidBody> on every call to increase preformance
                ballRigidbody.AddTorque((Vector3.forward * diff.x + Vector3.right * -diff.y) * torqueAmount, ForceMode.VelocityChange);
            }
        }
        else {
            isPressing = false;
        }
    }
}