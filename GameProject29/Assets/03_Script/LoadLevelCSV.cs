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
    
    static public void LoadCSV(TextAsset csv, out LEVEL_CSV data) {

        LEVEL_CSV tempData = new LEVEL_CSV();
        tempData.enemyData = new List<ENEMY_DATA>();

        StringReader reader     = new StringReader(csv.text);
        List<string> splitLine  = new List<string>();
        
        while (reader.Peek() != -1) {

            string line = reader.ReadLine();
            
            for (int i = 0; i < line.Split(',').Length; ++i) {
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
                    enemy.hp        = float .Parse(splitLine[i + 5]);
                    enemy.defecnce  = float .Parse(splitLine[i + 7]);
                    
                    tempData.enemyData.Add(enemy);
                    break;
            }
        }

        data = tempData;
    }
}
