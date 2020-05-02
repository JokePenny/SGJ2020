using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}