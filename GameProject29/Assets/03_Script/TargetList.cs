using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetList : MonoBehaviour {

    [SerializeField] private List<GameObject> targetList = new List<GameObject>();
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
        targetList.Sort((a, b) =>
            Vector3.Distance(a.transform.position, parent.transform.position).CompareTo(
            Vector3.Distance(b.transform.position, parent.transform.position)));
    }

    public  void    AddList    (GameObject target) {
        targetList.Add(target);
    }

    public  void    RemoveList (GameObject target) {
        targetList.Remove(target);
    }
}
