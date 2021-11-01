using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour
{
    int score;
    public Text ResultText; //得点の文字の変数

    // Start is called before the first frame update
    void Start()
    {
        score = ScoreScript.getScore();
    }

    // Update is called once per frame
    void Update()
    {
        ResultText.text = "Score:" + score.ToString();
    }
}
