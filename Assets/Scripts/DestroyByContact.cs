using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
[SerializeField] private Collider coliderObject;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private PoolObject dataObject;

    void OnTriggerEnter(Collider other) 
    {
        dataObject.Rigidbody.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
