using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
     [System.Serializable]
    public class Pool
    {
        public string tag;
        public List<GameObject> prefabs;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake() 
    {
        Instance = this;
    }

    #endregion

    [SerializeField] private List<HumanData> humanSetting;
    [SerializeField] private List<CabbageData> cabbageSettings;
    [SerializeField] private List<Pool> pools;
    private Dictionary<string, Queue<PoolObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<PoolObject>>();

        foreach(Pool pool in pools)
        {
            Queue<PoolObject> objectPool = new Queue<PoolObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs[0]);
                obj.SetActive(false);
                obj.transform.SetParent(transform);

                objectPool.Enqueue(obj.GetComponent<PoolObject>());
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public Rigidbody SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exsist");
        }

        PoolObject objectToSpawn = poolDictionary[tag].Dequeue();

        if(tag == "Human")
        {
            ObjectData objectData = humanSetting[Random.Range(0, humanSetting.Count)];
            objectToSpawn.Init(objectData);
        }

        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.transform.position = position;

        //objectToSpawn.Rigidbody.velocity = transform.forward * objectToSpawn.Speed;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn.Rigidbody;
    }

    public void SpawnParticle(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exsist");
        }

        PoolObject objectToSpawn = poolDictionary[tag].Dequeue();
        
        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.transform.position = position;

        //objectToSpawn.Rigidbody.velocity = transform.forward * objectToSpawn.Speed;

        poolDictionary[tag].Enqueue(objectToSpawn);
    }
}
