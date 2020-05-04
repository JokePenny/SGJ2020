using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class HumanBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource soundCatch;
    [SerializeField] private List<Sprite> statusList;
    [SerializeField] private Rigidbody rgdbody;
    [SerializeField] private Boundary boundary;
    [SerializeField] private Vector2 direct;
    [SerializeField] private float timeMove;
    [SerializeField] private float timeWait;
    [SerializeField] private PoolObject data;
    [SerializeField] private float speed;
    [SerializeField] private Animator animateBody;
    [SerializeField] private Animation animateStatus;
    [SerializeField] private SpriteRenderer spriteStatus;
    [SerializeField] private int status;
    [SerializeField] private float statusDownTime;
    [SerializeField] private float statusDownTimeMax;
    [SerializeField] private GameObject playerExplosion;

    public bool isTouch;
    private bool isDead;

    public void Start()
    {
        data = GetComponent<PoolObject>();
        timeMove = UnityEngine.Random.Range(0, 10);
        timeWait = 0;
        direct = new Vector2(UnityEngine.Random.Range(boundary.xMin, boundary.xMax), UnityEngine.Random.Range(boundary.yMin, boundary.yMax));
        animateBody = GetComponent<Animator>();
        status = 2;
        spriteStatus.sprite = statusList[status];
    }

    public void BoomDead()
    {
        if(data.DestroedObject != null) data.DestroedObject(data);
        Instantiate(playerExplosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void Dead(GameController gameController)
    {
        gameController.AllDead -= Dead;
        BoomDead();
    }

    void FixedUpdate()
    {
        if(isDead) return;

        if(statusDownTime > 0)
        {
            statusDownTime -= Time.deltaTime;
        }
        else
        {
            statusDownTime = statusDownTimeMax;
            --status;
            if(status < 0)
            {
                animateBody.Play("HumanDead");
                isDead = true;
                return;
            }

            animateStatus.Play("ChangeStatus");
            spriteStatus.sprite = statusList[status];
        }

        if(timeWait > 0 || isTouch)
        {
            timeWait -= Time.deltaTime;
            rgdbody.velocity = new Vector2(0.0f, 0.0f);
            rgdbody.position = new Vector3
            (
                Mathf.Clamp(rgdbody.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rgdbody.position.y, boundary.yMin, boundary.yMax),
                0.0f
            );
            return;
        }

        if(timeMove > 0)
        {
            rgdbody.velocity = direct * speed;

            rgdbody.position = new Vector3
            (
                Mathf.Clamp(rgdbody.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rgdbody.position.y, boundary.yMin, boundary.yMax),
                0.0f
            );

            timeMove -= Time.deltaTime;
        }
        else
        {
            rgdbody.velocity = new Vector2(0.0f, 0.0f);
            direct = new Vector2(UnityEngine.Random.Range(boundary.xMin, boundary.xMax), UnityEngine.Random.Range(boundary.yMin, boundary.yMax));
            timeMove = UnityEngine.Random.Range(0, 10);
            timeWait = UnityEngine.Random.Range(0, 10);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Human")
        {
            ChangeDirection();
            return;
        }

        if (other.tag == "CabbageEat" && other.GetComponent<DestroyByContact>().goalObject.Equals(gameObject))
        {
            soundCatch.Play();
            statusDownTime = statusDownTimeMax;
            isTouch = false;
            timeMove = UnityEngine.Random.Range(0, 10);
            animateStatus.Play("ChangeStatus");
            status = status > 2 ? status : status + 1;
            spriteStatus.sprite = statusList[status];
        }
    }

    public void ChangeDirection()
    {
        direct = -direct;
        timeMove = UnityEngine.Random.Range(5, 10);
    }
}
