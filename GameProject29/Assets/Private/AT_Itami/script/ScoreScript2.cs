using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript2 : MonoBehaviour
{
    public static int Score; //得点の変数
    public Text ScoreText; //得点の文字の変数

    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //初期化
    }
    public void AddScore()
    {
        Score += 1000;
    }

    public static int getScore()
    {
        return Score;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score:" + Score.ToString(); //ScoreTextの文字をScore:Scoreの値にする

        //if (Input.GetKey(KeyCode.Space)) //もし、スペースキーがおされたら、
        //{
        //    Score += 1000; //Scoreを1000ずつ変える
        //}

    }
}
