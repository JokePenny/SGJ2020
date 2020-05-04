using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Asteroid") other.gameObject.SetActive(false);
    }
}