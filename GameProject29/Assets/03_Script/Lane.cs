using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

    public  float LaneSize      = 0.0f;
    public  float ObjectSize    = 0.0f;
    private float Distance      = 0.0f;
    public  float scrollSpeed   = 0.0f;

    public  GameObject          laneObject;

    [SerializeField]
    private List<GameObject>    copyObjects;

    private float startPos, endPos;
    Vector3 pos;

    void Start() {
        pos         =  this.GetComponent<Transform>().position;
        startPos    = pos.z;
        endPos      = pos.z + LaneSize;
        
        if (LaneSize != 0.0) Distance = LaneSize / ObjectSize;
        
        for (int n = 0; n < (int)Distance; ++n) {
            copyObjects.Add(Instantiate(laneObject));
            copyObjects[n].GetComponent<Transform>().position = new Vector3(pos.x, pos.y, startPos + (ObjectSize * n));
            copyObjects[n].transform.parent = this.transform;
        }
    }
    
    void Update() {
        foreach (var obj in copyObjects)  Scroll(obj);
    }

    void Scroll(GameObject obj) {

        obj.GetComponent<Transform>().position += new Vector3(0.0f, 0.0f, scrollSpeed * Time.deltaTime);

        if (obj.GetComponent<Transform>().position.z < startPos ) obj.GetComponent<Transform>().position = new Vector3(pos.x, pos.y, endPos);
        if (obj.GetComponent<Transform>().position.z > endPos   ) obj.GetComponent<Transform>().position = new Vector3(pos.x, pos.y, startPos);
    }
}
