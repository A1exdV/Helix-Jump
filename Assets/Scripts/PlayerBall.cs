using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float bounceForce;
    [SerializeField] private GameObject splashPrefab;
    [SerializeField] private Vector2 splashScale;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Unsafe"))
        {
            print("end");
            Time.timeScale = 0;
        }
        
        _rigidbody.velocity = Vector3.up*bounceForce*Time.deltaTime;

        var newSplash = Instantiate(splashPrefab,
            new Vector3(transform.position.x, collision.transform.position.y+0.24f, transform.position.z),
            transform.rotation);
        newSplash.transform.localScale = Vector3.one*Random.Range(splashScale.x,splashScale.y);
        newSplash.transform.localEulerAngles += new Vector3(0, 0, Random.Range(0, 360));
        newSplash.transform.parent = collision.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
