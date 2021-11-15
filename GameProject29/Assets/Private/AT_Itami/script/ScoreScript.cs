using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public static int Score; //得点の変数
    public Text ScoreText; //得点の文字の変数
    public static float dTime;


    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //初期化
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime;

        //Debug.Log("計測中： " + (dTime).ToString());
        ScoreText.text = "Score:" + Score.ToString(); //ScoreTextの文字をScore:Scoreの値にする
        
    }



    public void AddScoreE()//通常エネミー
    {
        Score += 300;
    }

    public void AddScoreWE()//雑魚エネミー
    {
        Score += 100;
    }
    public void AddScoreMBE()//中ボス
    {
        Score += 500;
    }
    public void AddScoreBE()//ボスエネミー
    {
        Score += 999;
    }
   
    public static int GetScore()
    {
        return Score;
    }

    public static float GetScoreTime()
    {
        return dTime;
    }
}
