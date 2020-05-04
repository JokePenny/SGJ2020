using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HihiCabbage : MonoBehaviour
{
    [SerializeField] private AudioSource soundCatch;
    private float time;

    void Start()
    {
        time = Random.Range(5, 20);
    }

    private void Update()
    {
        if(time <= 0)
        {
            time = Random.Range(5, 20);
            soundCatch.Play();
        }
        else time -= Time.deltaTime;
    }
}
