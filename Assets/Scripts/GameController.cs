using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerSpawnToNextHuman;
    [SerializeField] private Transform humanSpawner;
    [SerializeField] private HumanController humanController;
    [SerializeField] private MenuController menuController;
    [SerializeField] private float timer;
     [SerializeField] private float bestScoretimer;
    [SerializeField] private int totalCountHumanLive;
    [SerializeField] private int totalCountHumanLiveAndDie;

    [SerializeField] private float startWait;
    [SerializeField] private float spawnWait;
    private Coroutine spawnerHuman;
    private float spawnWaitNow;
    private bool isGameOver = false;

    public void StartGame()
    {
        spawnerHuman = StartCoroutine(SpawnWaves());
        spawnWait = startWait;
        spawnWaitNow = 0;
        isGameOver = false;
    }

    public void GameOver()
    {
        if(timer > bestScoretimer)
            PlayerPrefs.SetFloat("score", timer);
            
        isGameOver = true;
        StopGame();
    }

    public void StopGame()
    {
        StopCoroutine(spawnerHuman);
        menuController.OpenMainMenu();
    }

    public void HumanDie(PoolObject human)
    {
        --totalCountHumanLive;
        if(totalCountHumanLive == 0) GameOver();
    }

    private IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            Vector3 spawnPosition = humanSpawner.position;
            Quaternion spawnRotation = Quaternion.identity;
            Rigidbody human = ObjectPooler.Instance.SpawnFromPool("Human", spawnPosition, spawnRotation);
            if(human != null)
            {
                totalCountHumanLive++;
                human.GetComponent<PoolObject>().DestroedObject += HumanDie;
                human.GetComponent<PoolObject>().DestroedObject += humanController.HumanDie;
                humanController.DestroedObject += human.GetComponent<HumanBehavior>().DownSatus;
            }
            else continue;
            if(totalCountHumanLive == 0) break;
            spawnWaitNow = 0;
            spawnWait += 5;
            yield return new WaitForSeconds (spawnWait);
        }
    }

    private void Update()
    {
        if(!isGameOver)
        {
            timer += Time.deltaTime;
            timerSpawnToNextHuman.fillAmount = spawnWaitNow / spawnWait;
            spawnWaitNow += Time.deltaTime;
        }
    }
}
