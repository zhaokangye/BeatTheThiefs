using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    private int thief_life;
    public float movespeed;
    private float timeVal;
    private float existVal;
    private int existTime;
    private float h;
    private float v;
    private SpriteRenderer sr;
    public Sprite[] playerSprite;
    bool isDead = false;

    private void Awake()
    {
        thief_life = life - 1;
        timeVal = 3;
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject isPlayer=GameObject.Find("Player");
        GameObject isPlayerClone = GameObject.Find("Player(Clone)");
        if ( isPlayer == null)
        {
            if (isPlayerClone == null)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }

        if (isDead)
        {
            ThiefDestory();
            if (existVal >= 0.2f)
            {
                existTime++;
            }
            else
            {
                existVal += Time.deltaTime;
            }
        }
    }
    private void FixedUpdate()
    {
        if(isDead==false)
            Move();
    }

    public void GetHit()
    {
        if (thief_life > 0)
        {
            thief_life--;
        }
        else
        {
            isDead = true;
        }
    }
    public void ThiefDestory()
    {
        sr.sprite = playerSprite[4];
        if (existTime == 2)
        {
            GameObject.Find("ScoreNum").SendMessage("Incr");
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        
        if (timeVal >= 1.5f)
        {
            int num = Random.Range(0, 8);
            if (num > 6)
            {
                //下
                v = -1;
                h = 0;
                sr.sprite = playerSprite[0];
            }
            else if (num > 0 && num <= 2)
            {
                //上
                v = 1;
                h = 0;
                sr.sprite = playerSprite[1];
            }
            else if (num > 2 && num <= 4)
            {
                //左
                v = 0;
                h = -1;
                sr.sprite = playerSprite[2];
            }
            else if (num >4&&num<=6)
            {
                //右
                v = 0;
                h = 1;
                sr.sprite = playerSprite[3];
            }

            timeVal = 0;

        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }
        
        transform.Translate(Vector3.right * h * movespeed * Time.fixedDeltaTime, Space.World);
        transform.Translate(Vector3.up * v * movespeed * Time.fixedDeltaTime, Space.World);
    }
}
