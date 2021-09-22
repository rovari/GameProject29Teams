using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetList : MonoBehaviour {

    private GameObject  parent;
    public  string      tagName;

    [SerializeField] private List<GameObject> targetList = new List<GameObject>();

    // Unity Function ===============================================

    private void Start  () {
        parent      = gameObject.transform.root.gameObject;
        targetList.AddRange(GameObject.FindGameObjectsWithTag(tagName));

        StartCoroutine("ListUpdate");
    }
    
    // User  Function ===============================================

    private void        ListSortToDistance  () {
        targetList.Sort((a, b) =>
            Vector3.Distance(a.transform.position, parent.transform.position).CompareTo(
            Vector3.Distance(b.transform.position, parent.transform.position)));
    }

    private IEnumerator ListUpdate          () {
        while (true) {

            targetList.Clear();
            targetList.AddRange(GameObject.FindGameObjectsWithTag(tagName));
            ListSortToDistance();

            yield return new WaitForSeconds(0.1f);
        }
    }

    public  GameObject GetTarget(int index) {
        return targetList[index];
    }
}
