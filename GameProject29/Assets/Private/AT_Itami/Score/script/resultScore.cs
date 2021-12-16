using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class resultScore : MonoBehaviour
{
    int crushing;
    static int TotalScore;
    static int ClearScore;
    float Tmp;
    float ClearTime;
    float Ma;//倍率
    public Text ResultText; //得点の文字の変数]

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

        crushing = ScoreScript.GetCrushing();
        Tmp = crushing * Ma;
        crushing = (int)Tmp;
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore =
            ClearScore +//クリア総得点
            crushing;//撃破数

        ResultText.text = "Score:" + TotalScore.ToString();
    }

    public static int GetTotalScore()
    {
        return TotalScore;
    }

    public static int GetClearScore()
    {
        return ClearScore;
    }
  
}
