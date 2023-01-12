using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class HelixParts : MonoBehaviour
{
    [SerializeField] private Material unSafe;
    [SerializeField] private string unSafeTag;
    [SerializeField] private GameObject[] helixPart;
    [SerializeField] private float radius;
    [SerializeField] private float force;
    private Transform _player;
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        Destroy(helixPart[Random.Range(0, helixPart.Length - 1)]);
    }

    public void Instantiate(bool isFirst)
    {
        if(isFirst)
            return;
        for (var i = 0; i < helixPart.Length-1; i++)
        {
            var num = Random.Range(0, 10);
            if(num>8)
                Destroy(helixPart[i]);
            if (num > 6)
            {
                helixPart[i].GetComponent<MeshRenderer>().material = unSafe;
                helixPart[i].tag = unSafeTag;
            }
        }
    }

    private void Update()
    {
        if (transform.position.y > _player.position.y)
        {
            foreach (var ring in helixPart)
            {
                if (ring.gameObject != null)
                {
                   var rb = ring.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                   
                    Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                   
                    rb.AddExplosionForce(force,transform.position,radius);
                    ring.transform.parent = null;
                    ring.GetComponent<MeshCollider>().enabled = false;
                    StartCoroutine(DestroyRing(ring));
                }
            }
            
        }
    }

    private IEnumerator DestroyRing(GameObject ring)
    {
        yield return new WaitForSeconds(1f);
        Destroy(ring);
    }
}
