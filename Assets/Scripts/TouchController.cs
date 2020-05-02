using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Transform cabbageSpawn;
    [SerializeField] private float fireRate;
    private float nextFire;
    public float acceloration;

    void Update()
    {
        #if UNITY_EDITOR
        if(Time.time > nextFire){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null){
                if (hit.collider.gameObject.tag == "Human"){
                    hit.collider.GetComponent<HumanBehavior>().isTouch = true;
                    Rigidbody rb = ObjectPooler.Instance.SpawnFromPool("Cabbage", cabbageSpawn.position, cabbageSpawn.rotation);
                    nextFire = Time.time + fireRate;
                    Debug.Log(nextFire);
                    Debug.Log(Time.time);
                    //if(rb == null) return;
                    rb.AddForce((hit.collider.gameObject.transform.position - cabbageSpawn.position) * acceloration, 
                        ForceMode.Impulse);
                }   
            }
        }
        #endif


        // if(Input.touchCount > 0)
        // {
        //     RaycastHit hit;
        //     //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        //     Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //     Debug.Log(transform.forward);
        //     //пускаем луч
        //     Physics.Raycast(ray, out hit);

        //     //если луч с чем-то пересёкся, то..
        //     if (hit.collider != null){
        //         //если луч не попал в цель
        //         if (hit.collider.gameObject.tag == "Human"){
        //             Debug.Log("Путь к врагу преграждает объект: "+ hit.collider.name);
        //             Debug.DrawLine(ray.origin, hit.point,Color.red);
        //         }   
        //     }
        // }
    }
}
