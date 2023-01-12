using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private GameObject ringEndPrefab;
    [SerializeField] private float ringDistance;

    public int ringsCount;
    
    void Start()
    {
        Instantiate();
    }
    
    public void Instantiate()
    {
        var newRing = Instantiate(ringEndPrefab, Vector3.zero, Quaternion.identity);
        newRing.transform.SetParent(this.gameObject.transform);
        for (var i = 1; i < ringsCount; i++)
        {
            newRing = Instantiate(ringPrefab, new Vector3(0, ringDistance * i,0), Quaternion.identity);
            
            if(i==ringsCount-1)
                newRing.GetComponent<HelixParts>().Instantiate(true);
            else
                newRing.GetComponent<HelixParts>().Instantiate(false);
            
            newRing.transform.SetParent(this.gameObject.transform);
        }
    }

}
