using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create LevelData")]
public class LevelData : ScriptableObject {

    public int          level;
    
    // Stage Setting
    [Space(10)]
    public Color        lineColor;
    public string       stageBgm;
    public string       stageEnv;
    public string       stageName;

    // Enemy Setting
    [Space(10)]
    public string       lowEnemyName;
    public Texture      lowEnemyTex;
    public ActorState   lowEnemyState;

    [Space(10)]
    public string       middleEnemyName;
    public Texture      middleEnemyTex;
    public ActorState   middleEnemyState;

    [Space(10)]
    public string       highEnemyName;
    public Texture      highEnemyTex;
    public ActorState   highEnemyState;

    [Space(10)]
    public string       bossEnemyName;
    public Texture      bossEnemyTex;
    public ActorState   bossEnemyState;

    [Space(10)]
    public string       endBossEnemyName;
    public Texture      endBossEnemyTex;
    public ActorState   endBossEnemyState;
}
