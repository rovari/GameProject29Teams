using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    int Crusing;
    int CleatScore;
    int TotalScore;
}
public class ScoreManagement : MonoBehaviour
{
    Data scoreData = new Data()
    {

    };
    public int StageNo;//ステージ番号
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void GetStageInfo(int StageNo)
    {

    }
}
