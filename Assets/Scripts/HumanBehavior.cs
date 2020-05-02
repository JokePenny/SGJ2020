using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class HumanBehavior : MonoBehaviour
{
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
        timeMove = Random.Range(0, 10);
        timeWait = 0;
        direct = new Vector2(Random.Range(boundary.xMin, boundary.xMax), Random.Range(boundary.yMin, boundary.yMax));
        animateBody = GetComponent<Animator>();
        status = 2;
        spriteStatus.sprite = statusList[status];
    }

    public void BoomDead()
    {
        data.DestroedObject(data);
        Instantiate(playerExplosion, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void DownSatus(PoolObject obj)
    {
        if(!isDead)
        {
            --status;
            animateStatus.Play("ChangeStatus");
            if(status < 0)
            {
                spriteStatus.sprite = statusList[0];
                animateBody.Play("HumanDead");
                isDead = true;
                return;
            }
            spriteStatus.sprite = statusList[status];
        }
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
                3.28f
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
                3.28f
            );

            timeMove -= Time.deltaTime;
        }
        else
        {
            rgdbody.velocity = new Vector2(0.0f, 0.0f);
            direct = new Vector2(Random.Range(boundary.xMin, boundary.xMax), Random.Range(boundary.yMin, boundary.yMax));
            timeMove = Random.Range(0, 10);
            timeWait = Random.Range(0, 10);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Human")
        {
            ChangeDirection();
            return;
        }

        if (other.tag == "CabbageEat")
        {
            statusDownTime = statusDownTimeMax;
            isTouch = false;
            timeMove = Random.Range(0, 10);
            animateStatus.Play("ChangeStatus");
            status = status > 2 ? status : status + 1;
            spriteStatus.sprite = statusList[status];
            other.gameObject.SetActive(false);
        }
    }

    public void ChangeDirection()
    {
        direct = -direct;
        timeMove = Random.Range(0, 10);
        //timeMove = Random.Range(0, 10);
    }
}
