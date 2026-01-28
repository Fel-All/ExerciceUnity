using UnityEngine;
using System;
public class ZoneAtteinteSujet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject sphereActive;

    public event Action OnZoneAtteinte;
     void OnCollisionEnter(Collision collision)
    {
       
            Debug.Log("Collision");

            OnZoneAtteinte?.Invoke();
        
    }
    
}
