using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class SkillMoves : MonoBehaviour
{
    public Rigidbody rb;
    public float delay;
    public Vector3 elastico1;
    public Vector3 elastico2;
    private bool isCurrentlyColliding;
    public float jumpForce = 5f;
    private bool groundCheck;
    public static bool isJumped;
    public void skillMove()
    {
        StartCoroutine(SkillMove1());
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = 15f;
    }

    public IEnumerator SkillMove1()
    {
        rb.AddForce(elastico1, ForceMode.Impulse);
        yield return new WaitForSeconds(delay);
        rb.AddForce(elastico2, ForceMode.Impulse);
    }
    public void jumpMove()
    {
        if (groundCheck)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumped = true;
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
            isJumped = false;
        }
    }
}

