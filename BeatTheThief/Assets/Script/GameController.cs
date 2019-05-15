using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject Restart;
    public GameObject SpwanPoint;
    public GameObject SpwanPoint1;
    public GameObject SpwanPoint2;
    public GameObject ThiefPrefab;
    public GameObject PauseIcon1;
    public GameObject PauseIcon2;
    public float timeVal;
    public float IncVal;
    public float CreateEnemyRate;
    public int num;
    bool isCreate = false;
    bool isPause = false;
    private void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeVal >= CreateEnemyRate&&isCreate==true)
        {
            CreateEnemy();
            Debug.Log(CreateEnemyRate);
        }
        else
        {
            timeVal += Time.deltaTime;
        }

        if (IncVal >= 6)
        {
            if (CreateEnemyRate > 1)
            {
                CreateEnemyRate = CreateEnemyRate - 0.5f;
            }
            IncVal = 0;
        }
        else
        {
            IncVal += Time.deltaTime;
        }

        GamePause();
    }
    public void Init()
    {
        Debug.Log("重新创建敌人");
        Restart.SetActive(false);
        PauseIcon1.SetActive(true);
        PauseIcon2.SetActive(false);
        heart1.SetActive(true);
        heart2.SetActive(false);
        heart3.SetActive(false);
        isCreate = true;
        CreateEnemyRate = 3;
        Instantiate(ThiefPrefab, SpwanPoint.transform.position, transform.rotation);
    }
    public void RestartAsk()
    {
        isCreate = false;
        Restart.SetActive(true);
    }
    public void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Debug.Log("出生点"+num);
        switch (num) {
            case 0:
                Instantiate(ThiefPrefab, SpwanPoint.transform.position, transform.rotation);
                break;
            case 1:
                Instantiate(ThiefPrefab, SpwanPoint1.transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(ThiefPrefab, SpwanPoint2.transform.position, transform.rotation);
                break;
        }
        timeVal = 0;
    }
    public void ShowLife(int life)
    {
        switch (life)
        {
            case 0:
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 1:
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
        }
    }
    public void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                PauseIcon1.SetActive(true);
                PauseIcon2.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
            }
            else
            {
                PauseIcon1.SetActive(false);
                PauseIcon2.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
        }
    }
}
