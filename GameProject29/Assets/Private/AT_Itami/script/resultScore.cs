using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour
{
    int score;
    public Text ResultText; //“¾“_‚Ì•¶š‚Ì•Ï”

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
