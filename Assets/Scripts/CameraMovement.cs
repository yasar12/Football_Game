using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;

    private Vector3 desiredCameraPosition;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (ballTransform != null)
        {
            desiredCameraPosition = ballTransform.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredCameraPosition, followSpeed * Time.deltaTime);
            transform.LookAt(targetPoint.position, Vector3.up);
        }
    }
}
