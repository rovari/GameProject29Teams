using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript2 : MonoBehaviour
{
    public static int Score; //���_�̕ϐ�
    public Text ScoreText; //���_�̕����̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //������
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
        ScoreText.text = "Score:" + Score.ToString(); //ScoreText�̕�����Score:Score�̒l�ɂ���

        //if (Input.GetKey(KeyCode.Space)) //�����A�X�y�[�X�L�[�������ꂽ��A
        //{
        //    Score += 1000; //Score��1000���ς���
        //}

    }
}
