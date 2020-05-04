using UnityEngine;
using System;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private ObjectData data;
    [SerializeField] private MeshRenderer meshObject;
    [SerializeField] private Rigidbody rgdbody;
    [SerializeField] private SpriteRenderer spriteHuman;
    public Action<PoolObject> DestroedObject;
    public Rigidbody Rigidbody
    {
        get{return rgdbody;}
        private set{}
    }

    void Start()
    {
        rgdbody = GetComponent<Rigidbody>();
    }

    public void Init(ObjectData data)
    {
        this.data = data;
        if(data is HumanData)
        {
            spriteHuman.sprite = (data as HumanData).SpriteObject;
        }
    }
}
