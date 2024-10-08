﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //config params

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //State
    Vector3 paddleToBallVector;
    bool hasStarted = false;

    //cathed component refrences
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position ;
        myAudioSource = GetComponent <AudioSource>();
        myRigidBody2D = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(hasStarted==false)
            {
                LockBallToPaddle();
            }
    }
    private void LockBallToPaddle()
    {
        Vector3 paddlePos = new Vector3(paddle1.transform.position.x,paddle1.transform.position.y,1);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void SET()
    {
        hasStarted = true;
        myRigidBody2D.velocity = new Vector3(xPush, yPush, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Vector2 velocityTweak = new Vector3(Random.Range(0f,randomFactor),Random.Range(0f,randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak; 
        }
    }
}
