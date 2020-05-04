using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text textRecord;
    [SerializeField] private Text textCountHuman;
    [SerializeField] private Boundary boundaryForAsteroid;
    [SerializeField] private Slider timerSpawnToNextHuman;
    [SerializeField] private Transform asteroidSpawner;
    [SerializeField] private MenuController menuController;
    [SerializeField] public int totalCountHumanLive;
    [SerializeField] private float spawnWaitStart;
    public Action<GameController> AllDead;

    private Coroutine spawnerHuman;
    private float spawnWaitNow;
    public bool isGameOver = false;
    private float spawnWait;

    private void Start() 
    {
        textRecord.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void StartGame()
    {
        textCountHuman.text = "0";
        spawnWait = spawnWaitStart;
        spawnWaitNow = 0;
        isGameOver = false;
        spawnerHuman = StartCoroutine(SpawnWaves());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        if(!isGameOver && AllDead != null)
        {
            isGameOver = true;
            AllDead(this);
        }
        
        isGameOver = true;
        int oldScore = PlayerPrefs.GetInt("score", -1);
        if(oldScore < totalCountHumanLive)
        {
            oldScore = totalCountHumanLive;
            PlayerPrefs.SetInt("score", totalCountHumanLive);
        }

        textRecord.text = oldScore.ToString();
        StopCoroutine(spawnerHuman);
        menuController.OpenMainMenu();
    }

    public void HumanDie(PoolObject human)
    {
        human.DestroedObject -= HumanDie;
        AllDead -=  human.GetComponent<HumanBehavior>().Dead;
        if(!isGameOver)
        {
            isGameOver = true;
            AllDead(this);
            GameOver();
        }
    }

    private IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (spawnWait);
        while (true)
        {
            Vector2 spawnPosition = asteroidSpawner.position;
            Quaternion spawnRotation = Quaternion.identity;
            Rigidbody asteroid = ObjectPooler.Instance.SpawnFromPool("Asteroid", spawnPosition, spawnRotation);
            Asteroid aster = asteroid.gameObject.GetComponent<Asteroid>();
            aster.target = new Vector2 (UnityEngine.Random.Range (boundaryForAsteroid.xMin, boundaryForAsteroid.xMax), UnityEngine.Random.Range (boundaryForAsteroid.yMin, boundaryForAsteroid.yMax));
            aster.spawn = true;
            spawnWaitNow = 0;
            if(spawnWait - 1 > 2) --spawnWait;
            yield return new WaitForSeconds (spawnWait);
        }
    }

    private void Update()
    {
        if(!isGameOver)
        {
            timerSpawnToNextHuman.value = spawnWaitNow / spawnWait;
            spawnWaitNow += Time.deltaTime;
        }
    }
}
