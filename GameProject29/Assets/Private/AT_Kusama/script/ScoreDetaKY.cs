using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDetaKY : MonoBehaviour
{
    public struct Date
    {
        public int StScore;
        public int StDefeat;
    }

    public static Date[] score_date = new Date[5];
  
    // Start is called before the first frame update
    void Start()
    {
        score_date[1] = new Date() { StScore = 100, StDefeat = 10 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ステージのデータの持ち出し（ステージナンバー）
    public static Date GetDate(int scene)
    {
        return score_date[scene];
    }

    //ステージのデータの持ち出しスコア（ステージナンバー）
    public static int GetScoreDate(int scene)
    {
        return score_date[scene].StScore;
    }

    //ステージのデータ更新（ステージナンバー　,スコア　,撃破数）
    public static void SetDate(int scene ,int score ,int defeat)
    { 
        score_date[scene] = new Date() { StScore = score, StDefeat = defeat };
    }

    //ステージのスコア更新（ステージナンバー　,スコア）
    public static void SetScoreDate(int scene, int score)
    {
        score_date[scene].StScore = score;
    }

    //ステージの撃破数更新（ステージナンバー　,撃破数）
    public static void SetDefeatDate(int scene, int defeat)
    {
        score_date[scene].StDefeat = defeat;
    }
}
