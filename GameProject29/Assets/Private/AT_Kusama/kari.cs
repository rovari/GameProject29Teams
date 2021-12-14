using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kari : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 0;
        a = ScoreDetaKY.GetScoreDate(1);
        Debug.Log(a);

        ScoreDetaKY.SetScoreDate(1, 100);
        a = ScoreDetaKY.GetScoreDate(1);
        Debug.Log(a);

        ScoreDetaKY.SetScoreDate(1, 200);
        a = ScoreDetaKY.GetScoreDate(1);
        Debug.Log(a);

        ScoreDetaKY.SetScoreDate(2, 300);
        a = ScoreDetaKY.GetScoreDate(2);
        Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
