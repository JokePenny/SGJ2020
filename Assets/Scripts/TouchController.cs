using UnityEngine.UI;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private Transform cabbageSpawn;
    public float fireRate;
    private float nextFire;
    public float acceloration;

    void Update()
    {
        if(Time.time > nextFire && Input.GetButton("Fire1")){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null){
                if (hit.collider.gameObject.tag == "Human"){
                    hit.collider.GetComponent<HumanBehavior>().isTouch = true;
                    Rigidbody rb = ObjectPooler.Instance.SpawnFromPool("Cabbage", cabbageSpawn.position, cabbageSpawn.rotation);
                    nextFire = Time.time + fireRate;
                    rb.GetComponent<DestroyByContact>().goalObject = hit.collider.gameObject;
                    rb.AddForce((hit.collider.gameObject.transform.position - cabbageSpawn.position) * acceloration, 
                        ForceMode.Impulse);
                }   
            }
        }
    }
}
