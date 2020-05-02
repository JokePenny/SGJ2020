using UnityEngine;
using System;

public class HumanController : MonoBehaviour
{
    public Action<PoolObject> DestroedObject;

    public void HumanDie(PoolObject obj)
    {
        obj.DestroedObject -= HumanDie;
        DestroedObject(obj);
        DestroedObject -= obj.GetComponent<HumanBehavior>().DownSatus;
    }
}
