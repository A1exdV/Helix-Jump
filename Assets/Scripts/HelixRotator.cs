using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        if (Input.touchCount>0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                var touchDeltaPosition = Input.GetTouch(0).deltaPosition.x;
                var position = transform.position;
                transform.Rotate(position.x, -touchDeltaPosition*rotationSpeed*Time.deltaTime,position.z);
            }
        }
    }
}
