using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{ //Branch Deneme 111111111111
    public Rigidbody rb;
    float touchPosX;
    float touchPosY;
    float touchDeltaX;
    float touchDeltaY;
    public float ballSpeed;
    public float airBallSpeed;
    public float groundBallSpeed;
    public bool groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballSpeed = 3.3f;
        airBallSpeed = 0.25f;
        groundBallSpeed = 3f;
    }

    void Update()
    {
        if (groundCheck) 
        { 
            ballSpeed = groundBallSpeed;
        }else if(SkillMoves.isJumped && Shooting.canShoot)
        {
            ballSpeed = groundBallSpeed;
        }else
        {
            ballSpeed = airBallSpeed; 
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                RotateBall(touch.deltaPosition);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("floor"))
        {
            groundCheck = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            groundCheck = true;
        }
    }

    private void RotateBall(Vector2 deltaPosition)
    {
        float touchX = deltaPosition.x;
        float touchY = deltaPosition.y;
        Vector3 rotation = new Vector3(touchX, 0f, touchY);
        rb.AddForce(rotation * ballSpeed);
    }
}
