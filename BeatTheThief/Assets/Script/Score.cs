using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private UILabel Label;
    private void Awake()
    {
        Label = GetComponent<UILabel>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        Label.text = "0";
    }
    public void Incr()
    {
        string string_num = Label.text;
        int int_num=int.Parse(string_num);
        int_num++;
        Label.text = int_num.ToString();
    }
}
