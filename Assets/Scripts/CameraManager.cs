using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]private Transform target;
    private Vector3 _offset;
    [SerializeField] private float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += target.position;
        _offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var newPos = Vector3.Lerp(transform.position, target.position + _offset,smoothSpeed);
        transform.position = newPos;
        
    }
}
