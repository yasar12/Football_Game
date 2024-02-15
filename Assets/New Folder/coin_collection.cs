using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_collection : MonoBehaviour
{
   
    [SerializeField] Transform coinplace;
    float speed = 0.1f;
    float _current, _target;
    [SerializeField] AnimationCurve curve;

    private void Awake()
    {
       
    }
    void Start()
    {

       
    }
    private void Update()
    {
         _target = 1;
        _current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, coinplace.transform.position, curve.Evaluate(_current));
      

    }

}

   
