using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {

    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    private GameObject parent;

    private void    Start() {
        parent      = this.gameObject.transform.root.gameObject;
        ListSortToDistance();
    }

    private void    FixedUpdate() {
        ListSortToDistance();
    }

    // User Function ===============================================

    private void    ListSortToDistance() {
        enemyList.Sort((a, b) =>
            Vector3.Distance(a.transform.position, parent.transform.position).CompareTo(
            Vector3.Distance(b.transform.position, parent.transform.position)));
    }

    public  void    AddEnemyList    (GameObject enemy) {
        enemyList.Add(enemy);
    }

    public  void    RemoveEnemyList (GameObject enemy) {
        enemyList.Remove(enemy);
    }
}
