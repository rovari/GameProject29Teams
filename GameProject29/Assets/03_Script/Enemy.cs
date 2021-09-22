using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject           player;
    public List<GameObject>     enemyLists;
    
    private void    Start() {
        enemyLists.AddRange(GameObject.FindGameObjectsWithTag("EnemyList"));
        AddList();
    }

    private void    Update() {

    }

    private void    OnDestroy() {
        RemoveList();
    }

    // User Function ===============================================

    private void    AddList() {
        foreach (var list in enemyLists) { list.GetComponent<EnemyList>().AddEnemyList(gameObject); }
    }

    private void    RemoveList() {
        foreach (var list in enemyLists) { list.GetComponent<EnemyList>().RemoveEnemyList(gameObject); }
    }
}
