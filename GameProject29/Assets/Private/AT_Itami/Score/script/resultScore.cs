using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour
{
    int score;
    int TotalScore;
    int ClearScore;
    float Tmp;
    float ClearTime;
    float Ma;//�{��
    public Text ResultText; //���_�̕����̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        ClearTime = ScoreScript.GetScoreTime();
        if (ClearTime < 210)
        {
            Ma = 2;
        }
        else if (ClearTime >= 210 && ClearTime <= 240)
        {
            Ma = 1.5f;
        }
        else if (ClearTime >= 240 && ClearTime <= 270)
        {
            Ma = 1.2f;
        }
        else
        {
            Ma = 1;
        }

        Tmp = 1000 * Ma;
        ClearScore = (int)Tmp;

        score = ScoreScript.GetScore();
        Tmp = score * Ma;
        score = (int)Tmp;
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore =
            ClearScore +//�N���A�����_
            score;//���j��

        ResultText.text = "Score:" + TotalScore.ToString();
    }

  
}
