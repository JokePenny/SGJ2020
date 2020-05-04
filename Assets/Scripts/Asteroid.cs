using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Text textCountHuman;
    public GameController gameController;
    [SerializeField] private float speed;

    public bool spawn = false;
    public Vector3 target;
    private void Start() 
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        textCountHuman = GameObject.Find("TextCountHuman").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if (Vector2.Distance(transform.position, target) < 0.001f)
        {
            SpawnHuman();
        }
    }

    private void SpawnHuman()
    {
        gameObject.SetActive(false);
        ObjectPooler.Instance.SpawnFromPool("BurstAsteroid", transform.position, transform.rotation);
        if(gameController.isGameOver)
        {
            return;
        }
        spawn = false;
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        Rigidbody human = ObjectPooler.Instance.SpawnFromPool("Human", spawnPosition, spawnRotation);
        if(human != null)
        {
            gameController.totalCountHumanLive++;
            textCountHuman.text = gameController.totalCountHumanLive.ToString();
            gameController.AllDead += human.GetComponent<HumanBehavior>().Dead;
            human.GetComponent<PoolObject>().DestroedObject += gameController.HumanDie;
        }
    }
}
