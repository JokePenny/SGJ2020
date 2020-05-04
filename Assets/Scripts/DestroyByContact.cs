using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
     public GameObject goalObject;
    [SerializeField] private Collider coliderObject;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private PoolObject dataObject;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.Equals(goalObject))
        {
            dataObject.Rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

        if(other.tag == "Boundary") dataObject.Rigidbody.velocity = Vector3.zero;
    }
}
