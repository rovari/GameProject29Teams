using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public static int Crushing; //���_�̕ϐ�
    public Text ScoreText; //���_�̕����̕ϐ�
    public static float dTime;


    // Start is called before the first frame update
    void Start()
    {
        Crushing = 0; //������
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime;

        //Debug.Log("�v�����F " + (dTime).ToString());
        ScoreText.text = "Score:" + Crushing.ToString(); //ScoreText�̕�����Score:Score�̒l�ɂ���
        
    }



    public void AddScoreE()//�ʏ�G�l�~�[
    {
        Crushing += 300;
    }

    public void AddScoreWE()//�G���G�l�~�[
    {
        Crushing += 100;
    }
    public void AddScoreMBE()//���{�X
    {
        Crushing += 500;
    }
    public void AddScoreBE()//�{�X�G�l�~�[
    {
        Crushing += 999;
    }
   
    public static int GetScore()
    {
        return Crushing;
    }

    public static float GetScoreTime()
    {
        return dTime;
    }
}
