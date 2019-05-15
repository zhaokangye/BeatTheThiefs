using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed;

    private Vector3 WeaponEulerAngles;

    private SpriteRenderer sr;

    public Sprite[] playerSprite;

    public GameObject weaponPrefab;

    private float timeVal;

    public float rate_of_fire;

    public int life=1;

    // Use this for initialization

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        WeaponEulerAngles = new Vector3(0, 0, -180);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeVal >= rate_of_fire)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Attack() {
        if (Input.GetKey(KeyCode.Space)) {
            Instantiate(weaponPrefab, transform.position,Quaternion.Euler(transform.eulerAngles+WeaponEulerAngles));
            timeVal = 0;
            GameObject.Find("Camera").SendMessage("Shake");
        }
    }
    public void Move() {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * movespeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = playerSprite[2];
            WeaponEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = playerSprite[3];
            WeaponEulerAngles = new Vector3(0, 0, -90);
        }

        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * v * movespeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = playerSprite[0];
            WeaponEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = playerSprite[1];
            WeaponEulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Heart":
                if (life < 3)
                {
                    life++;
                    Debug.Log("增加一点生命值，当前生命值：" + life);
                    GameObject.Find("GameController").SendMessage("ShowLife", life);
                }
                collision.gameObject.SendMessage("SelfDestory");
                break;
            case "Enemy":
                life--;
                Debug.Log("减少一点生命值，当前生命值：" + life);
                GameObject.Find("GameController").SendMessage("ShowLife", life);
                if (life ==0)
                {
                    Destroy(gameObject);
                    GameObject.Find("GameController").SendMessage("RestartAsk");
                }      
                break;
        }
    }

}
