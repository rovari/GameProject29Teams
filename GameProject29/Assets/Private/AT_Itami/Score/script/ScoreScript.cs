using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public static int Score; //���_�̕ϐ�
    public Text ScoreText; //���_�̕����̕ϐ�
    public static float dTime;


    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //������
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime;

        //Debug.Log("�v�����F " + (dTime).ToString());
        ScoreText.text = "Score:" + Score.ToString(); //ScoreText�̕�����Score:Score�̒l�ɂ���
        
    }



    public void AddScoreE()//�ʏ�G�l�~�[
    {
        Score += 300;
    }

    public void AddScoreWE()//�G���G�l�~�[
    {
        Score += 100;
    }
    public void AddScoreMBE()//���{�X
    {
        Score += 500;
    }
    public void AddScoreBE()//�{�X�G�l�~�[
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
