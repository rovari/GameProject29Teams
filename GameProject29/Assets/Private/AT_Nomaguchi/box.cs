using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

    Transform   player;
    Vector3     _velocity;
    Vector3     _targetPos;
    
    void Start() {

        player      = GameObject.FindGameObjectWithTag("Player").transform;
        _velocity   = Vector3.zero;
        _targetPos  = transform.position;
        _targetPos.y -= player.position.y;
    }
    
    void Update() {

        Vector3 calcPos;
        calcPos = new Vector3(player.position.x, _targetPos.y + player.position.y, _targetPos.z);
        
        transform.position = Vector3.SmoothDamp(transform.position, calcPos, ref _velocity, 0.05f);
    }
}
