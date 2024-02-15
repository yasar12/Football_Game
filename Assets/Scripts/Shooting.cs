using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shooting : MonoBehaviour
{
    public Rigidbody rb;
    public float shootForce = 0.05f;
    public Vector3 horizontalIncreaser;
    //public Vector2 goalTransform;
    private float touchTimeStart;
    private float touchTimeFinish;
    private float timeInterval;
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector3 direction;
    private bool isGrounded;
    public float maxHeight;
    public float multiplier;
    public bool groundCheck;
    public float testValue;
    public float soundThreshold;
    private bool preventRepeat;
    public static bool canShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootForce = 0.25f;
        testValue = -25f;
        canShoot = true; 
    // vertDecreaser = new Vector3(0f, -20f ,0f);
    }

    void Update()
    {
        
        if (transform.position.y > soundThreshold && preventRepeat)
        {
            preventRepeat = false;
            canShoot = true;
            AudioManager.PlayKickSound();
        }
        horizontalIncreaser = new Vector3(0f, 0f, 10f * testValue);
        if (groundCheck || SkillMoves.isJumped)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchTimeStart = Time.time;
                startPos = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                endPos = Input.GetTouch(0).position;
                direction = startPos - endPos;
                direction = new Vector3(direction.x , direction.y/3 , direction.z*testValue);
                direction += horizontalIncreaser;
               
                if(timeInterval > 0.065f)
                {
                    rb.AddForce(-direction /*/ timeInterval * shootForce*/);
                   Debug.Log("preventer worked");
                }
                else
                {
                    canShoot = false;
                    rb.AddForce(new Vector3(-direction.x , 0f , -direction.z) / shootForce);
                   
                }

            }
        }
        Debug.Log(canShoot + "    " + SkillMoves.isJumped);
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
            preventRepeat = true;
            canShoot = true;
        }
    }
}
