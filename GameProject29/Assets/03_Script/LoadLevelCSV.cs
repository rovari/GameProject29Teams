using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct STAGE_DATA {
    
    public  int     level;
    public  string  name;
    public  string  bgm;
    public  string  env;
    public  bool    end;
}

public struct ENEMY_DATA {

    public  string  name;
    public  int     life;
    public  float   hp;
    public  float   defecnce;
}

public struct LEVEL_CSV {
    
    public  STAGE_DATA          stageData;
    public  List<ENEMY_DATA>    enemyData;
}


public class LoadLevelCSV {
    
    [SerializeField] private TextAsset csv;
    private LEVEL_CSV   tempData; 
    private int         length  = 0;
    
    private void LoadCSV(out LEVEL_CSV data) {

        tempData = new LEVEL_CSV();

        StringReader reader     = new StringReader(csv.text);
        List<string> splitLine  = new List<string>();
        
        while (reader.Peek() != -1) {

            string line = reader.ReadLine();

            for (int i = 0; i < line.Length; ++i) {
                splitLine.Add(line.Split(',')[i]);
            }
        }
        
        for (int i = 0; i < splitLine.Count; ++i) {
            
            switch (splitLine[i]) {

                case "LEVEL"    : tempData.stageData.level  = int.Parse(splitLine[i + 1]);                      break;
                case "NAME"     : tempData.stageData.name   = splitLine[i + 1];                                 break;
                case "BGM"      : tempData.stageData.bgm    = splitLine[i + 1];                                 break;
                case "ENV"      : tempData.stageData.env    = splitLine[i + 1];                                 break;
                case "isEND"    : tempData.stageData.end    = (int.Parse(splitLine[i + 1]) > 0) ? true : false; break;
                    
                case "LOW"      :
                case "NORMAL"   :
                case "HIGH"     :
                case "BOSS"     :
                case "LAST"     :
                    ENEMY_DATA enemy;
                    enemy.name      = splitLine[i + 1];
                    enemy.life      = int   .Parse(splitLine[i + 3]);
                    enemy.hp        = float .Parse(splitLine[i + 6]);
                    enemy.defecnce  = float .Parse(splitLine[i + 9]);
                    break;
            }
        }

        data = tempData;
    }
    
    public LEVEL_CSV GetLevelCSV() {

        LEVEL_CSV data = new LEVEL_CSV();

        LoadCSV(out data);

        return data;
    }
}
