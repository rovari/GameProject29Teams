using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetList : MonoBehaviour {
    
    // Show  Field ================================================
    [SerializeField] private Transform          owner;
    [SerializeField] private string             _searchTag;
    [SerializeField] private List<GameObject>   _targetList;

    // User  Method ===============================================
    public  GameObject  GetTarget           (int index) {
        return (_targetList.Count > 0) ? _targetList[index] : null;
    }
    public  int         GetListSize         () {
        return _targetList.Count;
    }
    public  void        RefreshList         () {
        FindTargetWithTag   ();
        SortListByDistance  ();
    }
    private void        SortListByDistance  () { 

        if(_targetList.Count > 0) {

            _targetList.Sort((a, b) =>
                Vector3.Distance(a.transform.position, owner.position).CompareTo(
                Vector3.Distance(b.transform.position, owner.position)));
        }
    }
    private void        FindTargetWithTag   () {

        _targetList.Clear();
        _targetList.AddRange(GameObject.FindGameObjectsWithTag(_searchTag));
    }
}
