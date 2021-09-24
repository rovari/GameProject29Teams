using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetList : MonoBehaviour {

    public  string      tagName;
    private GameObject  parent;

    [SerializeField] private List<GameObject> targetList;

    // Unity Function ===============================================

    private void    Awake() {
        parent      = gameObject.transform.root.gameObject;
        targetList  = new List<GameObject>();
    }

    private void    OnEnable() {
        GetTargetListObject();
        ListSortToDistance ();
    }

    private void    OnDisable() {
        targetList.Clear();
    }

    // User  Function ===============================================

    private void        GetTargetListObject () {
        targetList.AddRange(GameObject.FindGameObjectsWithTag(tagName));
    }

    private void        ListSortToDistance  () {
        if (targetList.Count > 0) {
            targetList.Sort((a, b) =>
                Vector3.Distance(a.transform.position, parent.transform.position).CompareTo(
                Vector3.Distance(b.transform.position, parent.transform.position)));
        }
    }

    public  GameObject  GetTarget(int index) {

        if (targetList.Count <= 0) return null;

        return targetList[index];
    }
}
