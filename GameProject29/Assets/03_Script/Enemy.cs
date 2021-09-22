using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    [SerializeField]
    private List<GameObject>     targetList;
    
    private void    Start() {
        targetList.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        //AddList();
    }

    private void    Update() {

    }

    private void    OnDestroy() {
        //RemoveList();
    }

    // User Function ===============================================

    private void    AddList() {
        foreach (var list in targetList) { list.GetComponent<TargetList>().AddList(gameObject); }
    }

    private void    RemoveList() {
        foreach (var list in targetList) { list.GetComponent<TargetList>().RemoveList(gameObject); }
    }
}
