using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(PlayerPrefab, transform.position, transform.rotation);
            GameObject.Find("ScoreNum").SendMessage("Init");
            gameObject.SetActive(false);
            Debug.Log("正在重新开始游戏");
            GameObject.Find("GameController").SendMessage("Init");
        }
    }
}
